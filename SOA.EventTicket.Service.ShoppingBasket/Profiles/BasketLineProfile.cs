using AutoMapper;
using SOA.EventTicket.Service.ShoppingBasket.Models;

namespace SOA.EventTicket.Service.ShoppingBasket.Profiles
{
    public class BasketLineProfile :Profile
    {
        public BasketLineProfile()
        {
            CreateMap<BasketLineForCreation, Entities.BasketLine>();
            CreateMap<BasketLineForUpdate,Entities.BasketLine>();
            CreateMap<Entities.BasketLine,Models.BasketLine>().ReverseMap();

        }
    }
}
