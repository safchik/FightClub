using FightClub.Interfaces;
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
            var players = await _playerRepository.GetAllPlayersAsync();
            return View(players);
        }
    }
}
