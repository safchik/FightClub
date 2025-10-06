using FightClub.Data;
using FightClub.Interfaces;
using FightClub.Models;
using Microsoft.EntityFrameworkCore;

namespace FightClub.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly FightClubDbContext _context;
        public PlayerRepository(FightClubDbContext context)
        {
            _context = context;
        }
        public async Task AddPlayerAsync(Player player)
        {
            await _context.Users.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlayerAsync(int id)
        {
            var player = await _context.Users.FindAsync(id);
            if (player != null)
            {
                _context.Users.Remove(player);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Player> GetPlayerByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            _context.Users.Update(player);
            await _context.SaveChangesAsync();
        }
    }
}
