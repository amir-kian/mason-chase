using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Events;
using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Service.Interfaces;

namespace Mc2.CrudTest.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventDispatcher _eventDispatcher;

        public CustomerService(ICustomerRepository customerRepository, IEventDispatcher eventDispatcher)
        {
            _customerRepository = customerRepository;
            _eventDispatcher = eventDispatcher;
        }


        public Customer CreateCustomer(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
        {
            var customer = new Customer(firstName, lastName, dateOfBirth);
            customer.SetContactDetails(phoneNumber, email, bankAccountNumber);

            _customerRepository.Add(customer);

            var customerCreatedEvent = new CustomerCreatedEvent(
                customer.Id,
                customer.Firstname,
                customer.Lastname,
                customer.DateOfBirth,
                customer.PhoneNumber,
                customer.Email,
                customer.BankAccountNumber
            );
            _eventDispatcher.Dispatch(customerCreatedEvent);

            return customer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _customerRepository.GetById(customerId);
        }

        public void UpdateCustomer(int customerId, string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
        {
            var customer = _customerRepository.GetById(customerId);
            if (customer == null)
            {
                throw new ArgumentException($"Customer with ID {customerId} does not exist.");
            }
            customer.SetContactDetails(phoneNumber, email, bankAccountNumber);

            _customerRepository.Update(customer);

            var customerUpdatedEvent = new CustomerUpdatedEvent(
                customer.Id,
                customer.Firstname,
                customer.Lastname,
                customer.DateOfBirth,
                customer.PhoneNumber,
                customer.Email,
                customer.BankAccountNumber
            );

            _eventDispatcher.Dispatch(customerUpdatedEvent);
        }
        public void DeleteCustomer(int customerId)
        {
            var customer = _customerRepository.GetById(customerId);
            if (customer == null)
            {
                throw new ArgumentException($"Customer with ID {customerId} does not exist.");
            }
            _customerRepository.Delete(customer);

            // Create and dispatch the CustomerDeletedEvent
            var customerDeletedEvent = new CustomerDeletedEvent(customer.Id);
            _eventDispatcher.Dispatch(customerDeletedEvent);
        }




    }
}
