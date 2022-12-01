﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SOA.EventTicket.Service.ShoppingBasket.Models
{
    public class BasketLineForCreation
    {
        [Required]
        public Guid EventId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int TicketAmount { get; set; }
    }
}
