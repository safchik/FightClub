using FightClub.Interfaces;
using FightClub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FightClub.Data.Enum;
using System.Security.Claims;

namespace FightClub.Controllers
{
    [Authorize] // Only logged-in users can create characters
    public class CharacterController : Controller
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return RedirectToAction("Login", "Account");

            IEnumerable<Character> characters = await _characterRepository.GetCharactersByPlayerIdAsync(userId);
            return View(characters);
        }


        [HttpGet]
        public IActionResult Create()
        {
            // Get the logged-in player's Id
            var playerId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (playerId == null)
                return RedirectToAction("Login", "Account"); // make sure user is logged in

            // Pre-fill the PlayerId in the Character model
            var character = new Character
            {
                PlayerId = playerId
            };

            return View(character);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Character character)
        {
            if (!ModelState.IsValid)
            {
                return View(character);
            }

            character.PlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            character.CreatedAt = DateTime.UtcNow;

            // The character.PlayerId is already set from the GET action (logged-in user)
            await _characterRepository.AddAsync(character);

            return RedirectToAction("Index", "Profile");
        }

    }
}
