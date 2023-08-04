using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Events
{
    public class CustomerUpdatedEvent : IDomainEvent
    {
        public CustomerUpdatedEvent(int id, string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }
        public PhoneNumber PhoneNumber { get; }
        public Email Email { get; }
        public BankAccountNumber BankAccountNumber { get; }
    }
}
