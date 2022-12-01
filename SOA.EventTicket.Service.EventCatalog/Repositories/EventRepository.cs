using Microsoft.EntityFrameworkCore;
using SOA.EventTicket.Service.EventCatalog.DbContexts;
using SOA.EventTicket.Service.EventCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.EventCatalog.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public EventRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }


        public async Task<IEnumerable<Event>> GetEvents(Guid categoryId)
        {
            return await _eventCatalogDbContext.Events
                .Include(c => c.Category)
                .Where(e => (e.CategoryId == categoryId || categoryId == Guid.Empty))
                .ToListAsync();

        }

        public async Task<Event> GetByEventId(Guid eventId)
        {
            return await _eventCatalogDbContext.Events
                .Include(c => c.Category)
                .Where(e => e.EventId == eventId).FirstOrDefaultAsync();
        }
    }
}
