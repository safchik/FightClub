using FightClub.Data.Enum;

namespace FightClub.Models
{
    public class RaceStats
    {
        public int Id { get; set; }
        public Race Race { get; set; }
        public int MaxHP { get; set; }
        public int Attack {  get; set; }    
        public int Defense { get; set; }
        public int Mana { get; set; }
    }
}
