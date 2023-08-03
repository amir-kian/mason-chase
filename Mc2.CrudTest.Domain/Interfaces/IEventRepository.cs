

namespace Mc2.CrudTest.Domain.Interfaces
{
    public interface IEventRepository<TEvent> where TEvent : IDomainEvent
    {
        void AddEvent(TEvent @event);
        IEnumerable<TEvent> GetEvents();
    }
}
