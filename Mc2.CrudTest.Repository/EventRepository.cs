﻿using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Infrastructure;
using Newtonsoft.Json;

namespace Mc2.CrudTest.Repository
{
    public class EventRepository : IEventRepository<IDomainEvent>
    {
        private readonly AppDbContext _dbContext;

        public EventRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEvent(IDomainEvent @event)
        {
            var eventEntity = new Event
            {
                EventType = @event.GetType().Name,
                EventData = JsonConvert.SerializeObject(@event),
                CreatedAt = DateTime.Now
            };
            _dbContext.Events.Add(eventEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<IDomainEvent>> GetEvents()
        {
            return await Task.FromResult(_dbContext.Events.AsEnumerable());
        }
    }
}
