using Microsoft.EntityFrameworkCore;
using SOA.EventTicket.Service.ShoppingBasket.Entities;

namespace SOA.EventTicket.Service.ShoppingBasket.DbContexts
{
    public class ShoppingBasketDbContext : DbContext
    {
        public ShoppingBasketDbContext(DbContextOptions<ShoppingBasketDbContext> options):base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketLine> BasketLines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

        
        }
    }
}
