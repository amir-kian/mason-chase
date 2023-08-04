using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Repository
{
    public class WriteCustomerRepository : IWriteCustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public WriteCustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Add(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer.Id;
        }

        public async Task Delete(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }
    }
}
