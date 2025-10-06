using Microsoft.AspNetCore.Identity;

namespace FightClub.Models
{
    public class Player : IdentityUser
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property for characters
        public List<Character> Characters { get; set; } = new();
    }
}
