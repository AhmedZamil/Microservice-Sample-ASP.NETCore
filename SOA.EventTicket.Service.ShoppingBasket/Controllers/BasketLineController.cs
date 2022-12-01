using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SOA.EventTicket.Service.ShoppingBasket.Models;
using SOA.EventTicket.Service.ShoppingBasket.Repositories;
using SOA.EventTicket.Service.ShoppingBasket.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.ShoppingBasket.Controllers
{
    public class BasketLineController : Controller
    {
        private readonly IBasketLineRepository _basketLineRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IEventRepository _eventRepository;
        private readonly EventCatalogService _eventCatalogService;
        private readonly IMapper _mapper;

        public BasketLineController(IBasketLineRepository basketLineRepository,
            IBasketRepository basketRepository,
            IEventRepository eventRepository,
            EventCatalogService eventCatalogService,
            IMapper mapper)
        {
            _basketLineRepository = basketLineRepository;
            _basketRepository = basketRepository;
            _eventRepository = eventRepository;
            _eventCatalogService = eventCatalogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketLine>>> Get(Guid basketId)
        {
            if (! await _basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }
            var basketLines = await _basketLineRepository.GetBasketLines(basketId);
            return Ok(_mapper.Map<IEnumerable<BasketLine>>(basketLines));       
        }

        [HttpGet("{basketLineId}", Name = "GetBasketLines")]
        public async Task<ActionResult<BasketLine>> Get(Guid basketId,Guid basketLineId)
        { 
            var basket = await _basketRepository.GetBasketById(basketId);
            if (basket == null)
            {
                return NotFound();
            }
            var basketLines = await _basketLineRepository.GetBasketLineById(basketLineId);
            if (basketLines == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BasketLine>(basketLines));
        
        }


        [HttpPost("{basketLineId}")]
        public async Task<ActionResult<BasketLine>> Post(Guid basketId,
            [FromBody]BasketLineForCreation basketLine)
        {
            if (!await _basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }
            if (! await _eventRepository.EventExists(basketLine.EventId))
            {
                var missingEvent =await _eventCatalogService.GetEvent(basketLine.EventId);
                _eventRepository.AddEvent(missingEvent);
                await _eventRepository.SaveChanges();
            }
            var basketLineEntity = _mapper.Map<Entities.BasketLine>(basketLine);
            await _basketLineRepository.AddOrUpdateBasketLine(basketId,basketLineEntity);
            await _basketLineRepository.Savechanges();

            var basketLineToReturn = _mapper.Map<Models.BasketLine>(basketLine);
            return CreatedAtRoute("GetBasketLines",
                new { basketId = basketLineEntity .BasketId, basketLineId = basketLineEntity.BasketLineId },
                basketLineToReturn);        
        }

        [HttpPut]
        public async Task<ActionResult<BasketLine>> Put(Guid basketId, 
            Guid basketLineId,
            [FromBody]BasketLineForUpdate basketLineForUpdate)
        {
            if (!await _basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLineEntity = await _basketLineRepository.GetBasketLineById(basketLineId);
            if (basketLineEntity ==  null)
            {
                return NotFound();
            }
            _mapper.Map(basketLineForUpdate, basketLineEntity);
             _basketLineRepository.UpdateBasketLine(basketLineEntity);
            await _basketLineRepository.Savechanges();

            return Ok(_mapper.Map<BasketLine>(basketLineEntity));
        }

        [HttpDelete("basketLineId")]
        public async Task<IActionResult> Delete(Guid basketId,Guid basketLineId)
        {
            if (! await _basketRepository.BasketExists(basketId))
            {
                return NotFound();
            }

            var basketLineEntity = await _basketLineRepository.GetBasketLineById(basketLineId);
            if (basketLineEntity == null)
            {
                return NotFound();
            }
            _basketLineRepository.RemoveBasketLine(basketLineEntity);
            await _basketLineRepository.Savechanges();

            return NoContent();
        }

    }
}
