using FightClub.Data.Enum;
using FightClub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FightClub.Data
{
    public class FightClubDbContext : IdentityDbContext<Player>
    {
        public FightClubDbContext(DbContextOptions<FightClubDbContext> options) : base(options)
        {
            
        }

        
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CharacterItem> CharacterItems { get; set; }
        public DbSet<MarketItem> MarketItems { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<ItemRace> ItemRaces { get; set; }
        public DbSet<RaceStats> RaceStats { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique index on Email
            modelBuilder.Entity<Player>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // PLAYER CHARACTERS (1-to-many)
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Player)
                .WithMany(p => p.Characters)
                .HasForeignKey(c => c.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            // PLAYER ACTIVE CHARACTER (1-to-1) 
            modelBuilder.Entity<Player>()
                .HasOne(p => p.ActiveCharacter)
                .WithMany()
                .HasForeignKey(p => p.ActiveCharacterId)
                .OnDelete(DeleteBehavior.Restrict);

            // Battle relationships
            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Attacker)
                .WithMany()
                .HasForeignKey(b => b.AttackerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Defender)
                .WithMany()
                .HasForeignKey(b => b.DefenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Winner)
                .WithMany()
                .HasForeignKey(b => b.WinnerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ItemRace>()
                .HasOne(ir => ir.Item)
                .WithMany(i => i.ItemRaces)
                .HasForeignKey(ir => ir.ItemId);

            modelBuilder.Entity<RaceStats>()
                .HasData(
                    new RaceStats { Id = 1, Race = Race.Human, MaxHP = 100, Attack = 5, Defense = 5, Mana=100 },
                    new RaceStats { Id = 2, Race = Race.Elf, MaxHP = 120, Attack = 7, Defense = 3, Mana = 100 },
                    new RaceStats { Id = 3, Race = Race.Orc, MaxHP = 110, Attack = 6, Defense = 2, Mana = 100 },
                    new RaceStats { Id = 4, Race = Race.Dwarf, MaxHP = 110, Attack = 4, Defense = 6, Mana = 100 },
                    new RaceStats { Id = 5, Race = Race.Undead, MaxHP = 100, Attack = 5, Defense = 2 , Mana = 100 },
                    new RaceStats { Id = 6, Race = Race.Demon, MaxHP = 120, Attack = 4, Defense = 6 , Mana = 100 }
                );



            base.OnModelCreating(modelBuilder);
        }

    }
}
