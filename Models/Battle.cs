namespace FightClub.Models
{
    public class Battle
    {
        public int BattleId { get; set; }

        public int AttackerId { get; set; }
        public Player Attacker { get; set; }   

        public int DefenderId { get; set; }
        public Player Defender { get; set; }   

        public int? WinnerId { get; set; }
        public Player? Winner { get; set; }    

        public string? Log { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
