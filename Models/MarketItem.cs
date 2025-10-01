namespace FightClub.Models
{
    public class MarketItem
    {
        public int MarketItemId { get; set; }
        public int ItemId { get; set; }
        public Item? Item { get; set; }
        public int Stock { get; set; } 
        public DateTime ListedAt { get; set; }
    }
}
