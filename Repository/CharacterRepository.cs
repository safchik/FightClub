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

        // Delete existing character
        public async Task DeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }
        }

        // Get all characters
        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            return await _context.Characters
                .Include(c => c.Player)
                .AsNoTracking()
                .ToListAsync();
        }

        // Get a single character by ID
        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            return await _context.Characters
                                 .Include(c => c.Player)
                                 .Include(c => c.CharacterItems)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(c => c.CharacterId == id);
        }

        // Get all characters for a specific player
        public async Task<IEnumerable<Character>> GetCharactersByPlayerIdAsync(string playerId)
        {
            return await _context.Characters
                                 .Where(c => c.PlayerId == playerId)
                                 .Include(c => c.Player)
                                 .Include(c => c.CharacterItems)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // Fetch race stats for initialization
        public async Task<RaceStats?> GetRaceStatsByRaceAsync(Race race)
        {
            return await _context.RaceStats
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Race == race);
        }

        // Add item to character
        public async Task AddCharacterItemAsync(CharacterItem characterItem)
        {
            await _context.CharacterItems.AddAsync(characterItem);
            await _context.SaveChangesAsync();
        }


        // Update character
        public async Task UpdateAsync(Character character)
        {
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
        }


        // Save manually 
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        
    }
}
