using FightClub.Data.Enum;
using FightClub.Models;
using System.ComponentModel.DataAnnotations;

namespace FightClub.ViewModels
{
    public class CreateCharacterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Race Race { get; set; }

        public List<Item> AvailableWeapons { get; set; }
        public List<Item> AvailableArmors { get; set; }
        public List<Item> AvailablePotions { get; set; }
    }
}
