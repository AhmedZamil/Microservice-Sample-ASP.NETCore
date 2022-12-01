using Microsoft.EntityFrameworkCore;
using SOA.EventTicket.Service.ShoppingBasket.DbContexts;
using SOA.EventTicket.Service.ShoppingBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.ShoppingBasket.Repositories
{
    public class BasketLineRepository : IBasketLineRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public BasketLineRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }
        public async Task<BasketLine> AddOrUpdateBasketLine(Guid basketId, BasketLine basketLine)
        {
            var existingLine = await _shoppingBasketDbContext.BasketLines.Include(b => b.Event)
                .Where(bl => bl.BasketId == basketId && bl.EventId == basketLine.EventId)
                .FirstOrDefaultAsync();
            if (existingLine == null)
            {
                basketLine.BasketId = basketId;
                _shoppingBasketDbContext.BasketLines.Add(basketLine);
                return basketLine;           
            }
            existingLine.TicketAmount += basketLine.TicketAmount;
            return existingLine;
        }

        public async Task<BasketLine> GetBasketLineById(Guid basketLineId)
        {
            return await _shoppingBasketDbContext.BasketLines.Include(b => b.Event).Where(b => b.BasketLineId == basketLineId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BasketLine>> GetBasketLines(Guid basketId)
        {
            return await _shoppingBasketDbContext.BasketLines.Include(b => b.Event)
                .Where(bl => bl.BasketId == basketId).ToListAsync();
        }

        public void RemoveBasketLine(BasketLine basketLine)
        {
            _shoppingBasketDbContext.BasketLines.Remove(basketLine);
        }

        public async Task<bool> Savechanges()
        {
            return (await _shoppingBasketDbContext.SaveChangesAsync() > 0);
        }

        public void UpdateBasketLine(BasketLine basketLine)
        {
            // blank
        }
    }
}
