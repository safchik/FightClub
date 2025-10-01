using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
