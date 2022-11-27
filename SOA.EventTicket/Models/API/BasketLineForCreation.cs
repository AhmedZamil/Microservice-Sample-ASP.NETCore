using System;

namespace SOA.EventTicket.Models.API
{
    public class BasketLineForCreation
    {
        public Guid EventId { get; set; }
        public int TicketAmount { get; set; }
        public int Price { get; set; }

    }
}
