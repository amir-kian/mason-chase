using Mc2.CrudTest.Domain.Interfaces;


namespace Mc2.CrudTest.Domain.Events
{
    public class CustomerDeletedEvent : IDomainEvent
    {
        public CustomerDeletedEvent(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
