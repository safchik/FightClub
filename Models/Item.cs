using FightClub.Data.Enum;

namespace FightClub.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = "";
        public ItemType ItemType { get; set; }
        public int StatAttack { get; set; } = 0; 
        public int StatDefense { get; set; } = 0; 
        public int StatHP { get; set; } = 0; 
        public int Price { get; set; } = 0; 
        public DateTime CreatedAt { get; set; }
    }
}
