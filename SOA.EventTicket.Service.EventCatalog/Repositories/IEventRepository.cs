using SOA.EventTicket.Service.EventCatalog.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.EventCatalog.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents(Guid categoryId);
        Task<Event> GetByEventId(Guid eventId);

    }
}
