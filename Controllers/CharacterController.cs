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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Character character)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState
        //            .Where(e => e.Value.Errors.Any())
        //            .Select(e => $"{e.Key}: {string.Join(", ", e.Value.Errors.Select(er => er.ErrorMessage))}");
        //        Console.WriteLine("Validation Errors:\n" + string.Join("\n", errors));
        //        return View(character);
        //    }

        //    Get the logged -in player's ID
        //    var playerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    if (playerId == null)
        //    {
        //        ModelState.AddModelError("", "You must be logged in to create a character.");
        //        return View(character);
        //    }

        //    Check for duplicate names under the same player

        //   var existingCharacters = await _characterRepository.GetCharactersByPlayerIdAsync(playerId);
        //    if (existingCharacters.Any(c => c.Name.Equals(character.Name, StringComparison.OrdinalIgnoreCase)))
        //    {
        //        ModelState.AddModelError("Name", "You already have a character with this name.");
        //        return View(character);
        //    }

        //    Assign PlayerId and creation time(server - side, not from the form)
        //    character.PlayerId = playerId;
        //    character.CreatedAt = DateTime.UtcNow;

        //    Fetch race stats and apply base stats for the chosen race

        //   var raceStats = await _characterRepository.GetRaceStatsByRaceAsync(character.Race);
        //    if (raceStats != null)
        //    {
        //        character.MaxHP = raceStats.MaxHP;
        //        character.CurrentHP = raceStats.MaxHP;
        //        character.Attack = raceStats.Attack;
        //        character.Defense = raceStats.Defense;
        //        character.Mana = raceStats.Mana;
        //        character.CurrentMana = raceStats.Mana;
        //    }
        //    else
        //    {
        //        fallback defaults if race not found
        //        character.MaxHP = 100;
        //        character.CurrentHP = 100;
        //        character.Attack = 5;
        //        character.Defense = 5;
        //        character.Mana = 100;
        //        character.CurrentMana = 100;
        //    }

        //    character.Level = 1;
        //    character.Experience = 0;
        //    character.Gold = 0;

        //    Save to DB
        //   await _characterRepository.AddAsync(character);

        //    Redirect to index or character details page
        //    return RedirectToAction("Index", "Character");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Character character)
        {
            Console.WriteLine($"[DEBUG] Create POST hit. Name={character.Name}, Race={character.Race}, Gender={character.Gender}");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("[DEBUG] ModelState is invalid!");
                foreach (var e in ModelState.Values.SelectMany(v => v.Errors))
                    Console.WriteLine("[ERROR] " + e.ErrorMessage);
            }

            // ✅ Get the current logged-in player's ID
            character.PlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            character.CreatedAt = DateTime.UtcNow;

            // ✅ Fetch Race Stats based on selected Race
            var raceStats = await _characterRepository.GetRaceStatsByRaceAsync(character.Race);

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
                Console.WriteLine($"⚠️ Race stats not found for {character.Race}");
            }

            // ✅ Initial values
            character.Level = 1;
            character.Experience = 0;
            character.Gold = 0;

            Console.WriteLine($"Final Character: {character.Name}, Race: {character.Race}, HP: {character.MaxHP}, Attack: {character.Attack}, Defense: {character.Defense}");

            // ✅ Save character
            await _characterRepository.AddAsync(character);

            Console.WriteLine($"Character {character.Name} created for player {character.PlayerId}");
            return RedirectToAction("Index", "Profile"); // or whichever page you want
        }


    }
}
