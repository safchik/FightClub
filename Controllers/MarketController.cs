using FightClub.Data;
using FightClub.Data.Enum;
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
        public IActionResult Index(ItemType? category)
        {
            List<Item> items = _context.Items.ToList();

            if (category.HasValue)
            {
                items = items.Where(i => i.ItemType == category.Value).ToList();
            }

            return View(items);
        }

        public IActionResult Details(int id) 
        {
            var item = _context.Items.FirstOrDefault(i => i.ItemId == id);
            if (item == null) 
            {
                return NotFound();
            }

            return PartialView("_ItemDetailsPartial", item);
        }
    }
}
