using SOA.EventTicket.Service.ShoppingBasket.Entities;
using System;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.ShoppingBasket.Repositories
{
    public interface IBasketRepository
    {
        void AddBasket(Basket basket);

        Task<bool> BasketExists(Guid basketId);
        Task<Basket> GetBasketById(Guid basketId);
        Task<bool> SaveChanges();
    }
}
