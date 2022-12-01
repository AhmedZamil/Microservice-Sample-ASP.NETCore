using AutoMapper;
using SOA.EventTicket.Service.EventCatalog.Entities;
using SOA.EventTicket.Service.EventCatalog.Models;

namespace SOA.EventTicket.Service.EventCatalog.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventDto, Event>();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Entities.Event, Models.EventDto>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
        }
    }
}
