using FightClub.Data;
using FightClub.Data.Enum;
using FightClub.Interfaces;
using FightClub.Models;
using Microsoft.EntityFrameworkCore;

namespace FightClub.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly FightClubDbContext _context;
        public CharacterRepository(FightClubDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Character character)
        {
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            return await _context.Characters.Include(c => c.Player).ToListAsync();
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            return await _context.Characters
                                 .Include(c => c.Player)
                                 .FirstOrDefaultAsync(c => c.CharacterId == id);
        }

        public async Task<IEnumerable<Character>> GetCharactersByPlayerIdAsync(string playerId)
        {
            return await _context.Characters
                                 .Where(c => c.PlayerId == playerId)
                                 .Include(c => c.Player)
                                 .ToListAsync();
        }

        public async Task<RaceStats?> GetRaceStatsByRaceAsync(Race race)
        {
            return await _context.RaceStats.FirstOrDefaultAsync(r => r.Race == race);
        }



        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task UpdateAsync(Character character)
        {
            _context.Characters .Update(character);
            await _context.SaveChangesAsync();
        }
    }
}
