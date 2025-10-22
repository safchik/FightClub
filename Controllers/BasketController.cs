using FightClub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FightClub.Helpers;
using FightClub.Models;

namespace FightClub.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly PlayerContextService _playerContextService;

        public BasketController(
            IBasketRepository basketRepository,
            ICharacterRepository characterRepository,
            PlayerContextService playerContextService)
        {
            _basketRepository = basketRepository;
            _characterRepository = characterRepository;
            _playerContextService = playerContextService;
        }

        public async Task<IActionResult> Index()
        {
            var activeCharacter = await _playerContextService.GetActiveCharacterAsync(User);
            if (activeCharacter == null)
            {
                TempData["Error"] = "You must choose a character first.";
                return RedirectToAction("Index", "Profile");
            }

            var basketItems = await _basketRepository.GetBasketItemByCharacterIdAsync(activeCharacter.CharacterId);
            return View(basketItems);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int itemId)
        {
            var activeCharacter = await _playerContextService.GetActiveCharacterAsync(User);
            if (activeCharacter == null)
                return RedirectToAction("Index", "Profile");

            await _basketRepository.AddToBasketAsync(activeCharacter.CharacterId, itemId);
            await _basketRepository.SaveAsync();

            return RedirectToAction("Index", "Market");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int basketItemId)
        {
            await _basketRepository.RemoveFromBasketAsync(basketItemId);
            await _basketRepository.SaveAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var activeCharacter = await _playerContextService.GetActiveCharacterAsync(User);
            if (activeCharacter == null)
                return RedirectToAction("Index", "Profile");

            var basketItems = await _basketRepository.GetBasketItemByCharacterIdAsync(activeCharacter.CharacterId);
            var totalCost = basketItems.Sum(b => b.Item.Price);

            if (activeCharacter.Gold < totalCost)
            {
                TempData["Error"] = "Not enough gold.";
                return RedirectToAction("Index");
            }

            // Deduct gold
            activeCharacter.Gold -= totalCost;

            // Add items to inventory
            foreach (var basketItem in basketItems)
            {
                var charItem = new CharacterItem
                {
                    CharacterId = activeCharacter.CharacterId,
                    ItemId = basketItem.ItemId
                };
                await _characterRepository.AddCharacterItemAsync(charItem);
            }

            // Clear basket
            await _basketRepository.ClearBasketAsync(activeCharacter.CharacterId);
            await _basketRepository.SaveAsync();

            TempData["Success"] = "Purchase successful!";
            return RedirectToAction("Index", "Character");
        }
    }
}
