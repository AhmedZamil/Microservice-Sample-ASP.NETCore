using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SOA.EventTicket.Service.ShoppingBasket.Models;
using SOA.EventTicket.Service.ShoppingBasket.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.ShoppingBasket.Controllers
{
    [Route("api/baskets")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository,IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet("{basketId}",Name ="GetBasket")]
        public async Task<ActionResult<Basket>> Get(Guid basketId)
        { 
            var basket = await _basketRepository.GetBasketById(basketId);
            if (basket == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<Basket>(basket);
            result.NumberOfItems = basket.BasketLines.Sum(b=>b.TicketAmount);
            return Ok(result);
        
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> Post(BasketForCreation basketForCreation)
        {
            var basketEntity = _mapper.Map<Entities.Basket>(basketForCreation);
             _basketRepository.AddBasket(basketEntity);
            await _basketRepository.SaveChanges();

            var basketOnReturn = _mapper.Map<Basket>(basketEntity);
            return CreatedAtRoute(
                "GetBasket", 
                new { basketid= basketEntity.BasketId},
                basketOnReturn);
        }
    }
}
