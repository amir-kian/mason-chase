using Mc2.CrudTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Service.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Customer GetById(int customerId);
        void Update(Customer customer);
        void Delete(Customer customer);
        IEnumerable<Customer> GetAllCustomers();

    }
}
