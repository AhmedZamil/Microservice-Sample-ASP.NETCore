using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SOA.EventTicket.Service.ShoppingBasket.Entities
{
    public class Basket
    {
        public Guid BasketId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Collection<BasketLine> BasketLines { get; set; }
    }
}
