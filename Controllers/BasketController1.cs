using FightClub.Data;
using Microsoft.AspNetCore.Mvc;
using FightClub.Extensions;


namespace FightClub.Controllers
{
    public class BasketController1 : Controller
    {
        private readonly FightClubDbContext _context;
        public BasketController1(FightClubDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddToBasket(int itemId)
        {
            var basket = HttpContext.Session.GetObjectFromJson<List<int>>("Basket") ?? new List<int>();

            basket.Add(itemId);

            HttpContext.Session.SetObjectAsJson("Basket", basket);

            return RedirectToAction("Index", "Market");
        }
        public IActionResult Index()
        {
            var basketIds = HttpContext.Session.GetObjectFromJson<List<int>>("Basket") ?? new List<int>();
            var items = _context.Items.Where(i => basketIds.Contains(i.ItemId)).ToList();

            return View(items);
        }
    }
}
