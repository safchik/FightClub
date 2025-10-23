using FightClub.Models;

namespace FightClub.Interfaces
{
    public interface IMarketRepository
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item?> GetItemByIdAsync(int id);
    }
}
