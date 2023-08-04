using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;

using TechTalk.SpecFlow;
using Xunit;

namespace Test.BDD
{
    [Binding]
    public class CustomerSteps
    {
        private string firstname;
        private string lastname;
        private DateTime dateOfBirth;
        private PhoneNumber phoneNumber;
        private Email email;
        private BankAccountNumber bankAccountNumber;
        private Customer customer;

        [Given(@"I have entered the customer details")]
        public void GivenIHaveEnteredTheCustomerDetails()
        {
            firstname = "Amir";
            lastname = "Kian";
            dateOfBirth = new DateTime(1992, 10, 10);
            phoneNumber = new PhoneNumber("09216853858");
            email = new Email("javaheri_kian@yahoo.com");
            bankAccountNumber = new BankAccountNumber("09216853858");
        }

        [When(@"I create the customer")]
        public void WhenICreateTheCustomer()
        {
            customer = new Customer(firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber);
        }

        [Then(@"the customer object should be created successfully")]
        public void ThenTheCustomerObjectShouldBeCreatedSuccessfully()
        {
            Assert.NotNull(customer);
        }

        [Then(@"the customer details should be correct")]
        public void ThenTheCustomerDetailsShouldBeCorrect()
        {
            Assert.Equal(firstname, customer.Firstname);
            Assert.Equal(lastname, customer.Lastname);
            Assert.Equal(dateOfBirth, customer.DateOfBirth);
            Assert.Equal(phoneNumber, customer.PhoneNumber);
            Assert.Equal(email, customer.Email);
            Assert.Equal(bankAccountNumber, customer.BankAccountNumber);
        }
    }
}
