using FightClub.Data;
using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class BattleController : Controller
    {
        private readonly FightClubDbContext _context;
        public BattleController(FightClubDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
