using System.ComponentModel.DataAnnotations;

namespace SOA.EventTicket.Service.ShoppingBasket.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
