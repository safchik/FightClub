using FightClub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FightClub.Helpers
{
    public class PlayerContextService
    {
        private readonly UserManager<Player> _userManager;

        public PlayerContextService(UserManager<Player> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Player?> GetCurrentPlayerAsync(ClaimsPrincipal user)
        {
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return null;

            return await _userManager.Users
                .Include(p => p.ActiveCharacter)
                .ThenInclude(c => c.CharacterItems)
                .ThenInclude(ci => ci.Item)
                .FirstOrDefaultAsync(p => p.Id == userId);
        }

        public async Task<Character> GetActiveCharacterAsync(ClaimsPrincipal user)
        {
            var player = await GetCurrentPlayerAsync(user);
            return player?.ActiveCharacter;
        }
    }
}
