using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOA.EventTicket.Extensions;
using SOA.EventTicket.Grpc;
using SOA.EventTicket.Models;
using SOA.EventTicket.Models.API;
using SOA.EventTicket.Models.View;
using SOA.EventTicket.Services;
using System;
using System.Threading.Tasks;

namespace SOA.EventTicket.Controllers
{

    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService eventCatalogService;
        private readonly Events.EventsClient _eventCataloggRPCService;
        private readonly IShoppingBasketService shoppingBasketService;
        private readonly Settings settings;

        public EventCatalogController(IEventCatalogService eventCatalogService,
            IShoppingBasketService shoppingBasketService,Events.EventsClient eventCataloggRPCService,
            Settings settings)
        {
            this.eventCatalogService = eventCatalogService;
            _eventCataloggRPCService = eventCataloggRPCService;
            this.shoppingBasketService = shoppingBasketService;
            this.settings = settings;
        }

        public async Task<IActionResult> Index(Guid categoryid)
        {
            var currentBasketId = Request.Cookies.GetCurrentBasketId(settings);
            var getbasket = currentBasketId == Guid.Empty? Task.FromResult<Basket>(null): shoppingBasketService.GetBasket(currentBasketId);

            var getCategory = eventCatalogService.GetCategories();
            var getEvents = categoryid == Guid.Empty ? eventCatalogService.GetAll() :
                eventCatalogService.GetByCategoryId(categoryid);

            await Task.WhenAll(new Task[] { getbasket,getCategory, getEvents });

            var numOfItems = getbasket.Result == null ? 0 : getbasket.Result.NoOfItems;

            return View(new EventListModel { 
                Events= getEvents.Result,
                Categories = getCategory.Result,
                NumberOfItems = numOfItems,
                SelectedCategory = categoryid     
            });
        }

        [HttpPost]
        public IActionResult SelectCategory([FromForm] Guid selectedCategory)
        {
            return RedirectToAction("Index", new { categoryId = selectedCategory });
        }

        public async Task<IActionResult> Detail(Guid eventId)
        {
            var ev = await eventCatalogService.GetEvent(eventId);
            return View(ev);
        }
    }
}
