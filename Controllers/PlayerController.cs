using FightClub.Data;
using FightClub.Interfaces;
using FightClub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Player> players = await _playerRepository.GetAllPlayersAsync();
            return View(players);
        }
    }
}
