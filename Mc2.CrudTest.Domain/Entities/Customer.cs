using Mc2.CrudTest.Domain.ValueObjects;
using System;

namespace Mc2.CrudTest.Domain.Entities
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Email Email { get; set; }
        public BankAccountNumber BankAccountNumber { get; set; }

        private Customer() { }

        public Customer(string firstname, string lastname, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;

            ValidatePhoneNumber(phoneNumber);
            PhoneNumber = phoneNumber;

            ValidateEmail(email);
            Email = email;

            ValidateBankAccountNumber(bankAccountNumber);
            BankAccountNumber = bankAccountNumber;
        }

        public void Update(string firstname, string lastname, DateTime dateOfBirth)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
        }

        private void ValidatePhoneNumber(PhoneNumber phoneNumber)
        {
            if (phoneNumber != null)
            {
                var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                var parsedPhoneNumber = phoneNumberUtil.Parse(phoneNumber.Value, "IR");

                if (!phoneNumberUtil.IsValidNumber(parsedPhoneNumber))
                {
                    throw new ArgumentException("Invalid phone number. Please provide a valid mobile number.");
                }
            }
        }

        private void ValidateEmail(Email email)
        {
            if (email != null && !IsValidEmail(email.Value))
            {
                throw new ArgumentException("Invalid email address. Please provide a valid email address.");
            }
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains("@");
        }

        private void ValidateBankAccountNumber(BankAccountNumber bankAccountNumber)
        {
            if (bankAccountNumber != null && !IsValidBankAccountNumber(bankAccountNumber.Value))
            {
                throw new ArgumentException("Invalid bank account number. Please provide a valid bank account number.");
            }
        }

        private bool IsValidBankAccountNumber(string bankAccountNumber)
        {
            return !string.IsNullOrEmpty(bankAccountNumber);
        }
    }
}