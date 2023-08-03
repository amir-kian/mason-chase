

namespace Mc2.CrudTest.Domain.Interfaces
{
    public interface IEventDispatcher
    {
        void Dispatch<TEvent>(TEvent @event) where TEvent : IDomainEvent;
    }
}
