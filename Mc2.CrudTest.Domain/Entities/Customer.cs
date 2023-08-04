using Mc2.CrudTest.Domain.ValueObjects;
using PhoneNumbers;

namespace Mc2.CrudTest.Domain.Entities
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Mc2.CrudTest.Domain.ValueObjects.PhoneNumber PhoneNumber { get;  set; }
        public Email Email { get;  set; }
        public BankAccountNumber BankAccountNumber { get;  set; }

        private Customer() { }

        public Customer(string firstname, string lastname, DateTime dateOfBirth, Mc2.CrudTest.Domain.ValueObjects.PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            ValidatePhoneNumber(phoneNumber);
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }

        public void Update(string firstname, string lastname, DateTime dateOfBirth)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
        }

        private void ValidatePhoneNumber(Mc2.CrudTest.Domain.ValueObjects.PhoneNumber phoneNumber)
        {
            if (phoneNumber != null)
            {
                var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                var parsedPhoneNumber = phoneNumberUtil.Parse(phoneNumber.Value, "IR");

                if (!phoneNumberUtil.IsValidNumber(parsedPhoneNumber))
                {
                    throw new ArgumentException("Invalid phone number. Please provide a valid mobile number.");
                }
            }
        }
    }
}