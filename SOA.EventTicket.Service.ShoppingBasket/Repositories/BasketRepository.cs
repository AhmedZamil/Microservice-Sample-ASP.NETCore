using Microsoft.EntityFrameworkCore;
using SOA.EventTicket.Service.ShoppingBasket.DbContexts;
using SOA.EventTicket.Service.ShoppingBasket.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.ShoppingBasket.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public BasketRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }
        public void AddBasket(Basket basket)
        {
            _shoppingBasketDbContext.Baskets.Add(basket);
        }

        public async Task<bool> BasketExists(Guid basketId)
        {
            return await _shoppingBasketDbContext.Baskets.AnyAsync(b => b.BasketId == basketId);
        }

        public async Task<Basket> GetBasketById(Guid basketId)
        {
            return await _shoppingBasketDbContext.Baskets.Where(b => b.BasketId == basketId || basketId == Guid.Empty).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _shoppingBasketDbContext.SaveChangesAsync() > 0);
        }
    }
}
