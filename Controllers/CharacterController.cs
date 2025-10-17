using FightClub.Interfaces;
using FightClub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FightClub.Controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        // -------------------------
        // CHARACTER LIST (INDEX)
        // -------------------------
        public async Task<IActionResult> Index()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            IEnumerable<Character> characters = await _characterRepository.GetCharactersByPlayerIdAsync(userId);
            return View(characters);
        }

        // -------------------------
        // CREATE CHARACTER (GET)
        // -------------------------
        [HttpGet]
        public IActionResult Create()
        {
            string? playerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (playerId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Character character = new Character
            {
                PlayerId = playerId
            };

            return View(character);
        }

        // -------------------------
        // CREATE CHARACTER (POST)
        // -------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Character character)
        {
            Console.WriteLine($"[DEBUG] Create POST hit. Name={character.Name}, Race={character.Race}, Gender={character.Gender}");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("[DEBUG] ModelState is invalid!");
                foreach (var e in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("[ERROR] " + e.ErrorMessage);
                }
                return View(character);
            }

            // Get logged-in user
            string? playerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (playerId == null)
            {
                ModelState.AddModelError("", "You must be logged in to create a character.");
                return View(character);
            }

            // Check duplicate names for this player
            IEnumerable<Character> existingCharacters = await _characterRepository.GetCharactersByPlayerIdAsync(playerId);
            bool nameExists = existingCharacters.Any(c => c.Name.Equals(character.Name, StringComparison.OrdinalIgnoreCase));
            if (nameExists)
            {
                ModelState.AddModelError("Name", "You already have a character with this name.");
                return View(character);
            }

            // Assign player and timestamps
            character.PlayerId = playerId;
            character.CreatedAt = DateTime.UtcNow;

            // Fetch race stats
            RaceStats? raceStats = await _characterRepository.GetRaceStatsByRaceAsync(character.Race);
            if (raceStats != null)
            {
                character.MaxHP = raceStats.MaxHP;
                character.CurrentHP = raceStats.MaxHP;
                character.Attack = raceStats.Attack;
                character.Defense = raceStats.Defense;
                character.Mana = raceStats.Mana;
                character.CurrentMana = raceStats.Mana;
            }
            else
            {
                Console.WriteLine($" Race stats not found for {character.Race}");
                // fallback defaults
                character.MaxHP = 100;
                character.CurrentHP = 100;
                character.Attack = 5;
                character.Defense = 5;
                character.Mana = 100;
                character.CurrentMana = 100;
            }

            // Initialize defaults
            character.Level = 1;
            character.Experience = 0;
            character.Gold = 0;

            Console.WriteLine($"Final Character: {character.Name}, Race: {character.Race}, HP: {character.MaxHP}, Attack: {character.Attack}, Defense: {character.Defense}");

            // Save character
            await _characterRepository.AddAsync(character);

            Console.WriteLine($" Character '{character.Name}' created for player {character.PlayerId}");
            return RedirectToAction("Index", "Profile");
        }
    }
}
