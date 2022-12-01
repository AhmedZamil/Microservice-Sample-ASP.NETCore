using SOA.EventTicket.Service.ShoppingBasket.Entities;
using SOA.EventTicket.Service.ShoppingBasket.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.ShoppingBasket.Service
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient _client;

        public EventCatalogService(HttpClient client)
        {
            _client = client;
        }
        public async Task<Event> GetEvent(Guid eventId)
        {
            var response = await _client.GetAsync($"/api/events/{eventId}");
            return await response.ReadContentAs<Event>();
        }
    }
}
