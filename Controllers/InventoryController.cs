using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
