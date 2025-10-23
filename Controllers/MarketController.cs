using FightClub.Data;
using FightClub.Data.Enum;
using FightClub.Helpers;
using FightClub.Interfaces;
using FightClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class MarketController : Controller
    {
        private readonly FightClubDbContext _context;
        private readonly IMarketRepository _marketRepository;
        private readonly PlayerContextService _playerContextService;
        public MarketController(FightClubDbContext context, IMarketRepository marketRepository, PlayerContextService playerContextService)
        {
            _context = context;
            _marketRepository = marketRepository;
            _playerContextService = playerContextService;
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
