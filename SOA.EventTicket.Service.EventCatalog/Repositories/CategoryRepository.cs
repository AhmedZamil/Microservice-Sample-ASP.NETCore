using Microsoft.EntityFrameworkCore;
using SOA.EventTicket.Service.EventCatalog.DbContexts;
using SOA.EventTicket.Service.EventCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.EventCatalog.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public CategoryRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _eventCatalogDbContext.Categries.ToListAsync();
        }

        public async Task<Category> GetCategoryById(string categoryId)
        {
            return await _eventCatalogDbContext.Categries.Where(c => c.CategoryId.ToString() == categoryId).FirstOrDefaultAsync();
        }
    }
}
