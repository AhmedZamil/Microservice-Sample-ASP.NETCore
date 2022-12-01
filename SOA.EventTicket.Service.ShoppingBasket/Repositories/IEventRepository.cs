using SOA.EventTicket.Service.ShoppingBasket.Entities;
using System;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.ShoppingBasket.Repositories
{
    public interface IEventRepository
    {
        void AddEvent(Event theEvent);
        Task<bool> EventExists(Guid eventId);
        Task<bool> SaveChanges();
    }
}
