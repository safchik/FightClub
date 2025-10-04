using System.ComponentModel.DataAnnotations;

namespace FightClub.Models
{
    public class BasketItem
    {
        [Key]
        public int BasketItemId { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; } = 1;

        public int CharacterId { get; set; } // or character id if you tie basket to a character
        public Player Player { get; set; }
    }
}
