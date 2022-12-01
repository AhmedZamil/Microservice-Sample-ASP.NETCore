using SOA.EventTicket.Service.ShoppingBasket.Entities;
using System;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.ShoppingBasket.Service
{
    public interface IEventCatalogService
    {
        Task<Event> GetEvent(Guid eventId);
    }
}
