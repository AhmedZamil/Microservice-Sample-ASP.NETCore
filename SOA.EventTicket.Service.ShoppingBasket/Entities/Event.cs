using System;

namespace SOA.EventTicket.Service.ShoppingBasket.Entities
{
    public class Event
    {
        public Guid EventId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
