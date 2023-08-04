using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Entities
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public PhoneNumber PhoneNumber { get;  set; }
        public Email Email { get;  set; }
        public BankAccountNumber BankAccountNumber { get;  set; }

        private Customer() { }  

        public Customer(string firstname, string lastname, DateTime dateOfBirth)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
        }

        public void SetContactDetails(PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
        {
            if (phoneNumber != null)
            {
                PhoneNumber = phoneNumber;
            }

            if (email != null)
            {
                Email = email;
            }

            if (bankAccountNumber != null)
            {
                BankAccountNumber = bankAccountNumber;
            }
        }
        public void Update(string firstname, string lastname, DateTime dateOfBirth)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
        }
    }
}