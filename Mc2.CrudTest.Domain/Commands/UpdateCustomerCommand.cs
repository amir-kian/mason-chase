using Mc2.CrudTest.Domain.ValueObjects;
using MediatR;

public class UpdateCustomerCommand : IRequest<Unit>
{
    public int Id { get; }
    public string Firstname { get; }
    public string Lastname { get; }
    public DateTime DateOfBirth { get; }
    public string PhoneNumber { get; }
    public string Email { get; }
    public BankAccountNumber BankAccountNumber { get; }

    public UpdateCustomerCommand(int id, string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, BankAccountNumber bankAccountNumber)
    {
        Id = id;
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }
}