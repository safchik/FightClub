using FightClub.Interfaces;
using FightClub.Models;
using FightClub.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterRepository _characterRepository;
        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Character> characters = await _characterRepository.GetAllCharactersAsync();
            return View(characters);
        }
    }
}
