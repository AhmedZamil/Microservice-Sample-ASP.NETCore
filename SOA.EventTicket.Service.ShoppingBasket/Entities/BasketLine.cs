using System;
using System.ComponentModel.DataAnnotations;

namespace SOA.EventTicket.Service.ShoppingBasket.Entities
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }
        public Guid BasketId { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        
        [Required]
        public int TicketAmount { get; set; }

        [Required]
        public int Price { get; set; }

        public Basket Basket { get; set; }
    }
}
