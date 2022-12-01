using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.ShoppingBasket.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"There is something wrong {response.ReasonPhrase}");
            }
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive=true});
        
        }
    }
}
