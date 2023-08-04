

namespace Mc2.CrudTest.Domain.Interfaces
{
    public interface IEventRepository<T> where T : IDomainEvent
    {
        Task AddEvent(T @event);
        Task<IEnumerable<T>> GetEvents();
    }
}
