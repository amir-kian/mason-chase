namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class BankAccountNumber
    {
        public string Value { get; private set; }

        public BankAccountNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Bank account number cannot be null or empty.");
            }

            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}

