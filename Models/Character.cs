using FightClub.Data.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FightClub.Models
{
    public class Character
    {
        public int CharacterId { get; set; }

        [BindNever]
        public string PlayerId { get; set; }  
        
        public string Name { get; set; } = string.Empty;

        public string? Class { get; set; }

        [BindNever]
        public int Level { get; set; } = 1;

        [BindNever]
        public int Experience { get; set; } = 0;

        [BindNever]
        public int MaxHP { get; set; }

        [BindNever]
        public int CurrentHP { get; set; }

        [BindNever]
        public int Attack { get; set; }

        [BindNever]
        public int Defense { get; set; }

        [BindNever]
        public int Mana { get; set; }

        [BindNever]
        public int CurrentMana { get; set; }

        [BindNever]
        public int Gold { get; set; } = 0;

        [BindNever]
        public DateTime CreatedAt { get; set; }

        public Gender Gender { get; set; }
        public Race Race { get; set; }

        public Player? Player { get; set; }
        public List<CharacterItem> CharacterItems { get; set; } = new();
    }
}
