using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
