namespace FightClub.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } 
        public bool EmailConfirmed { get; set; }
        public List<Character> Characters { get; set; } = new();
    }
}
