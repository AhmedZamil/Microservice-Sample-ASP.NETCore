using System;

namespace SOA.EventTicket.Models.API
{
    public class BasketLineForUpdate
    {
        public Guid BasketLineId { get; set; }
        public int TicketAmount { get; set; }
    }
}
