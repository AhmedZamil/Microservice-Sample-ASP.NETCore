using System;
using System.ComponentModel.DataAnnotations;

namespace SOA.EventTicket.Service.ShoppingBasket.Models
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
