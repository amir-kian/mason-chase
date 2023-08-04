using Mc2.CrudTest.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Domain.Commands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

        public CreateCustomerCommand(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
    }
}
