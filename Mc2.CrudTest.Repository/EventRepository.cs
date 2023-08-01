using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _dbContext;

        public EventRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddEvent(Event @event)
        {
            _dbContext.Events.Add(@event);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetEvents()
        {
            return _dbContext.Events;
        }
    }
}
