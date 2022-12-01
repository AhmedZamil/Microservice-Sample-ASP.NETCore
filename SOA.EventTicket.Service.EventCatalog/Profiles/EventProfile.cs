using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using SOA.EventTicket.Grpc;

namespace SOA.EventTicket.Service.EventCatalog.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Entities.Event, Models.EventDto>()
    .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
            CreateMap<Entities.Event, Event>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date.ToUniversalTime().ToTimestamp()));
        }
    }
}
