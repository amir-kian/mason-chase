using Microsoft.EntityFrameworkCore;
using Mc2.CrudTest.Domain.Entities;
namespace Mc2.CrudTest.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.OwnsOne(c => c.PhoneNumber);
                entity.OwnsOne(c => c.Email);
                entity.OwnsOne(c => c.BankAccountNumber);
            });
        }
    }
}