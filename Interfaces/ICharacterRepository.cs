using FightClub.Models;

namespace FightClub.Interfaces
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetAllCharactersAsync();
        Task<Character> GetCharacterByIdAsync(int id);
        Task AddAsync(Character character);
        Task UpdateAsync(Character character);
        Task DeleteAsync(int id);
        bool Save();
    }
}
