using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
