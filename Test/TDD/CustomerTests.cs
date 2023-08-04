using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;
using Xunit;

namespace Test.TDD
{
    public class CustomerTests
    {
        [Fact]
        public void CreateCustomer_WithValidData_CreatesCustomerObject()
        {
            // Arrange
            string firstname = "Amir";
            string lastname = "Kian";
            var dateOfBirth = new DateTime(1992, 10, 10);
            var phoneNumber = new PhoneNumber("09216853858");
            var email = new Email("javaheri_kian@yahoo.com");
            var bankAccountNumber = new BankAccountNumber("09216853858");

            // Act
            var customer = new Customer(firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber);

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(firstname, customer.Firstname);
            Assert.Equal(lastname, customer.Lastname);
            Assert.Equal(dateOfBirth, customer.DateOfBirth);
            Assert.Equal(phoneNumber, customer.PhoneNumber);
            Assert.Equal(email, customer.Email);
            Assert.Equal(bankAccountNumber, customer.BankAccountNumber);
        }

        [Fact]
        public void CreateCustomer_WithInvalidPhoneNumber_ThrowsArgumentException()
        {
            // Arrange
            string firstname = "Amir";
            string lastname = "Kian";
            var dateOfBirth = new DateTime(1990, 1, 1);
            var invalidPhoneNumber = new PhoneNumber("123"); // Invalid phone number

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var customer = new Customer(firstname, lastname, dateOfBirth, invalidPhoneNumber, null, null);
            });
        }

        [Fact]
        public void CreateCustomer_WithInvalidEmail_ThrowsArgumentException()
        {
            // Arrange
            string firstname = "Amir";
            string lastname = "Kian";
            var dateOfBirth = new DateTime(1990, 1, 1);
            var invalidEmail = new Email("Amir"); // Invalid email address

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var customer = new Customer(firstname, lastname, dateOfBirth, null, invalidEmail, null);
            });
        }

        [Fact]
        public void CreateCustomer_WithInvalidBankAccountNumber_ThrowsArgumentException()
        {
            // Arrange
            string firstname = "Amir";
            string lastname = "Kian";
            var dateOfBirth = new DateTime(1990, 1, 1);
            var invalidBankAccountNumber = new BankAccountNumber(""); 

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var customer = new Customer(firstname, lastname, dateOfBirth, null, null, invalidBankAccountNumber);
            });
        }


    }
}