using FightClub.Data;
using FightClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class MarketController : Controller
    {
        private readonly FightClubDbContext _context;
        public MarketController(FightClubDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Item> items = _context.Items.ToList();
            return View(items);
        }
    }
}
