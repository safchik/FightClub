namespace FightClub.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public int PlayerId { get; set; }   
        public string Name { get; set; } = "";
        public string? Class { get; set; }
        public int Level { get; set; } = 1; 
        public int Experience { get; set; } = 0;
        public int MaxHP { get; set; } = 100;
        public int CurrentHP { get; set; } = 100;
        public int Attack { get; set; } = 5;
        public int Defense { get; set; } = 3;
        public int Gold { get; set; } = 0;
        public DateTime CreatedAt { get; set; }

        public Player? Player { get; set; }
        public List<CharacterItem> CharacterItems { get; set; } = new();
    }
}
