using Mc2.CrudTest.Domain.Entities;


namespace Mc2.CrudTest.Domain.Interfaces
{
    public interface IReadCustomerRepository
    {
        Task<Customer> GetById(int id);
        Task<List<Customer>> GetAll();
        Task<List<Customer>> GetAllCustomers();
    }
}
