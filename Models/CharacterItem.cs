namespace FightClub.Models
{
    public class CharacterItem
    {
        public int CharacterItemId { get; set; }
        public int CharacterId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; } = 1; 
        public Character? Character { get; set; }
        public Item? Item { get; set; }
    }
}
