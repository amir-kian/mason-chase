﻿using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Events;
using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Domain.ValueObjects;
using MediatR;


namespace Mc2.CrudTest.Service.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IWriteCustomerRepository _repository;
        private readonly ICustomerEventHandler _customerEventHandler;

        public UpdateCustomerCommandHandler(IWriteCustomerRepository repository, ICustomerEventHandler customerEventHandler)
        {
            _repository = repository;
            _customerEventHandler = customerEventHandler;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetById(request.Id);

            if (customer == null)
            {
                throw new ArgumentException($"Customer with ID {request.Id} does not exist.");
            }

            customer.Update(request.Firstname, request.Lastname, request.DateOfBirth);

            PhoneNumber phoneNumber = null;
            if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                phoneNumber = new PhoneNumber(request.PhoneNumber);
            }

            Email email = null;
            if (!string.IsNullOrEmpty(request.Email))
            {
                email = new Email(request.Email);
            }

            BankAccountNumber bankAccountNumber = null;
            if (!string.IsNullOrEmpty(request.BankAccountNumber.ToString()))
            {
                bankAccountNumber = new BankAccountNumber(request.BankAccountNumber.ToString());
            }

            customer.SetContactDetails(phoneNumber, email, bankAccountNumber);

            await _repository.Update(customer);

            var updatedEvent = new CustomerUpdatedEvent(
                customer.Id,
                customer.Firstname,
                customer.Lastname,
                customer.DateOfBirth,
                customer.PhoneNumber,
                customer.Email,
                customer.BankAccountNumber
            );
            await _customerEventHandler.Handle(updatedEvent);

            return Unit.Value;
        }
    }
}