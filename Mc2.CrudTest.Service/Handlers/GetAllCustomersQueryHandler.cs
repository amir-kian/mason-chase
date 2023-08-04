using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Domain.Queries;
using MediatR;
using Mc2.CrudTest.Core.DTOs;


namespace Mc2.CrudTest.Service.Handlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, CustomerReadDTO[]>
    {
        private readonly IReadCustomerRepository _repository;

        public GetAllCustomersQueryHandler(IReadCustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerReadDTO[]> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllCustomers();
            var result = new CustomerReadDTO[customers.Count];

            for (var i = 0; i < customers.Count; i++)
            {
                result[i] = new CustomerReadDTO
                {
                    Id = customers[i].Id,
                    Firstname = customers[i].Firstname,
                    Lastname = customers[i].Lastname,
                    DateOfBirth = customers[i].DateOfBirth,
                    PhoneNumber = customers[i].PhoneNumber.ToString(), // Convert PhoneNumber to string
                    Email = customers[i].Email.ToString() // Convert Email to string
                };
            }

            return result;
        }
    }
}
