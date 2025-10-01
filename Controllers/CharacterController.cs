using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class CharacterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
