using FightClub.Interfaces;
using FightClub.Models;
using FightClub.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Item> items = await _itemRepository.GetAllItemsAsync();
            return View(items);
        }
    }
}
