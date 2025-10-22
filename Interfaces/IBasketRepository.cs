using FightClub.Models;

namespace FightClub.Interfaces
{
    public interface IBasketRepository
    {
        Task<IEnumerable<BasketItem>> GetBasketItemByCharacterAsync(int characterId);
        Task AddToBasketAsync(int characterId, int itemId);
        Task RemoveFromBasketAsync(int basketItemId);
        Task ClearBasketAsync(int characterId);
        Task<bool> SaveAsync();
    }
}
