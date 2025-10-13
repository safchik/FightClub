using FightClub.Data;
using FightClub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FightClub.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly FightClubDbContext _context;
        private readonly UserManager<Player> _userManager;
        public ProfileController(FightClubDbContext context, UserManager<Player> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null) 
            {
                return RedirectToAction("Login", "Account");
            }

            var characters = await _context.Characters
                .Where(c => c.PlayerId == user.Id)
                .ToListAsync();

            ViewBag.Player = user;
            return View(characters);
        }
    }
}
