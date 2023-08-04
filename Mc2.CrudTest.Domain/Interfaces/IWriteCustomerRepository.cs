using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Domain.Interfaces
{
    public interface IWriteCustomerRepository
    {
        Task<int> Add(Customer entity);
        Task Update(Customer entity);
        Task Delete(Customer entity);
        Task<Customer> GetById(int id);
    }
}

