using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infrastructure;
using Mc2.CrudTest.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Customer customer)
        {
            _dbContext.Set<Customer>().Add(customer);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _dbContext.Set<Customer>().ToList();
        }

        public Customer GetById(int customerId)
        {
            return _dbContext.Set<Customer>().SingleOrDefault(c => c.Id == customerId);
        }

        public void Update(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _dbContext.Set<Customer>().Remove(customer);
            _dbContext.SaveChanges();
        }
    }
}