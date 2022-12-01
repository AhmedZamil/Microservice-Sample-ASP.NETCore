using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SOA.EventTicket.Service.EventCatalog.Models;
using SOA.EventTicket.Service.EventCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.EventCatalog.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository,IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> Get([FromQuery] Guid categoryId)
        {
            var result = await _eventRepository.GetEvents(categoryId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<EventDto>>(result));
        
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventDto>> GetById(Guid eventId)
        {
            var result = await _eventRepository.GetByEventId(eventId);
            return Ok(_mapper.Map<EventDto>(result));
        
        }



    }
}
