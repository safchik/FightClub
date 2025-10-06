using FightClub.Data.Enum;

namespace FightClub.Models
{
    public class ItemRace
    {
        public int Id { get; set; }

        // Relationships
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public Race Race { get; set; }
    }
}
