using SOA.EventTicket.Service.EventCatalog.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.EventCatalog.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(string categoryId);
    }
}
