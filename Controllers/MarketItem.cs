using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class MarketItem : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
