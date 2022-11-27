using System;
using System.ComponentModel.DataAnnotations;

namespace SOA.EventTicket.Models.API
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
