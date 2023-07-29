using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Email cannot be null or empty.");
            }

            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
