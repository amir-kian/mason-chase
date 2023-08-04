using Mc2.CrudTest.Core.DTOs;
using MediatR;

namespace Mc2.CrudTest.Domain.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerReadDTO>
    {
        public int CustomerId { get; set; }
    }
}
