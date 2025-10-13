using FightClub.Data.Enum;
using FightClub.Models;

public interface ICharacterRepository
{
    Task<IEnumerable<Character>> GetAllCharactersAsync();
    Task<Character> GetCharacterByIdAsync(int id); // single character
    Task<IEnumerable<Character>> GetCharactersByPlayerIdAsync(string playerId); // new
    Task<RaceStats?> GetRaceStatsByRaceAsync(Race race);
    Task AddAsync(Character character);
    Task UpdateAsync(Character character);
    Task DeleteAsync(int id);
    bool Save();
}
