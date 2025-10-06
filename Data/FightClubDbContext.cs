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




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique index on Email
            modelBuilder.Entity<Player>()
                .HasIndex(u => u.Email)
                .IsUnique();

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


            base.OnModelCreating(modelBuilder);
        }

    }
}
