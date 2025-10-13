using FightClub.Interfaces;
using FightClub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FightClub.Data.Enum;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

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

            // Get logged-in user ID
            character.PlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            character.CreatedAt = DateTime.UtcNow;
            character.Level = 1;
            character.Experience = 0;
            character.Gold = 0;

            // Get the race stats for this character's race
            var raceStats = await _characterRepository.GetRaceStatsByRaceAsync(character.Race);
            if (raceStats != null)
            {
                character.MaxHP = raceStats.MaxHP;
                character.CurrentHP = raceStats.MaxHP;
                character.Attack = raceStats.Attack;
                character.Defense = raceStats.Defense;
                character.Mana = raceStats.Mana;
                character.CurrentMana = raceStats.Mana;
                character.Gold = 0;
                character.CreatedAt = DateTime.UtcNow;
            }
            else
            {
                // fallback if somehow raceStats not found
                character.MaxHP = 100;
                character.CurrentHP = 100;
                character.Attack = 5;
                character.Defense = 3;
                character.Mana = 100;
                character.Gold = 0;
                character.CreatedAt = DateTime.UtcNow;
            }

            // The character.PlayerId is already set from the GET action (logged-in user)
            await _characterRepository.AddAsync(character);

            return RedirectToAction("Index", "Profile");
        }

    }
}
