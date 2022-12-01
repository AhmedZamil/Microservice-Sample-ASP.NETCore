using Microsoft.EntityFrameworkCore;
using SOA.EventTicket.Service.ShoppingBasket.DbContexts;
using SOA.EventTicket.Service.ShoppingBasket.Entities;
using System;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.ShoppingBasket.Repositories
{
    public class EventRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public EventRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }
        public void AddEvent(Event theEvent)
        {
            _shoppingBasketDbContext.Events.Add(theEvent);
        }

        public async Task<bool> EventExists(Guid eventId)
        {
            return await _shoppingBasketDbContext.Events.AnyAsync(e => e.EventId == eventId);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _shoppingBasketDbContext.SaveChangesAsync() > 0);
        }
    }
}
