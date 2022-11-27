using SOA.EventTicket.Models.API;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOA.EventTicket.Services
{
    public interface IEventCatalogService
    {
        public Task<IEnumerable<Event>> GetAll();
        public Task<IEnumerable<Event>> GetByCategoryId(Guid categoryid);
        public Task<Event> GetEvent(Guid id);
        public Task<IEnumerable<Category>> GetCategories();
    }
}
