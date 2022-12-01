using AutoMapper;
using SOA.EventTicket.Service.ShoppingBasket.Models;

namespace SOA.EventTicket.Service.ShoppingBasket.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Models.BasketForCreation, Entities.Basket>();
            CreateMap<Entities.Basket, Models.Basket>();
        }
    }
}
