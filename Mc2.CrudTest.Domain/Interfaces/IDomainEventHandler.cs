

namespace Mc2.CrudTest.Domain.Interfaces
{
    public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent
    {
        void Handle(TEvent @event);
    }
}
