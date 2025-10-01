using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class BattleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
