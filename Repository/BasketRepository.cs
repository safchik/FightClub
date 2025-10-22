using FightClub.Data;
using FightClub.Interfaces;
using FightClub.Models;
using Microsoft.EntityFrameworkCore;

namespace FightClub.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly FightClubDbContext _context;

        public BasketRepository(FightClubDbContext context)
        {
            _context = context;
        }

        public async Task AddToBasketAsync(int characterId, int itemId)
        {
            var existing = await _context.BasketItems
                .FirstOrDefaultAsync(b => b.CharacterId == characterId && b.ItemId == itemId);

            if (existing == null)
            {
                var basketItem = new BasketItem
                {
                    CharacterId = characterId,
                    ItemId = itemId
                };

                await _context.BasketItems .AddAsync(basketItem);
            }
        }

        public async Task ClearBasketAsync(int characterId)
        {
            var basketItems = _context.BasketItems.Where(b => b.CharacterId == characterId);
            _context.BasketItems.RemoveRange(basketItems);
        }

        public async Task<IEnumerable<BasketItem>> GetBasketItemByCharacterAsync(int characterId)
        {
            return await _context.BasketItems
                .Include(b => b.Item)
                .Where(b => b.CharacterId == characterId)
                .ToListAsync();
        }

        public async Task RemoveFromBasketAsync(int basketItemId)
        {
            var basketItem = await _context.BasketItems.FindAsync(basketItemId);
            if (basketItem != null)
            {
                _context.BasketItems.Remove(basketItem);
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
