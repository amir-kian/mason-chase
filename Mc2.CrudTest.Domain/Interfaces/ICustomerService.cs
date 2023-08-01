using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Service.Interfaces
{
    public interface ICustomerService
    {
        Customer CreateCustomer(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email Email, BankAccountNumber bankAccountNumber);
        Customer GetCustomerById(int customerId);
        IEnumerable<Customer> GetAllCustomers();
        void UpdateCustomer(int customerId, string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber);
        void DeleteCustomer(int customerId);
    }
}
