using Mc2.CrudTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Events
{
    public class CustomerDeletedEvent: IDomainEvent
    {
        public int Id { get; set; }
    }
}
