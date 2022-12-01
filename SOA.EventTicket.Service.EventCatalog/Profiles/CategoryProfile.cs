using AutoMapper;

namespace SOA.EventTicket.Service.EventCatalog.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Models.CategoryDto>().ReverseMap();
        }
    }
}
