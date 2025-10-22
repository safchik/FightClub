using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FightClub.Models
{
    public class BasketItem
    {
        [Key]
        public int BasketItemId { get; set; }

        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        public int Quantity { get; set; } = 1;

        public int CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public Character Character { get; set; }
    }
}
