using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Repository
{
    public class ReadCustomerRepository : IReadCustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public ReadCustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _dbContext.Set<Customer>().ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Set<Customer>().SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _dbContext.Set<Customer>().ToListAsync();
        }
    }
}
