using System;

namespace SOA.EventTicket.Models.API
{
    public class Basket
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public int NoOfItems { get; set; }
    }
}
