using Mc2.CrudTest.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.Entities
{
    public class Event : IDomainEvent
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string EventData { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
