using FightClub.Data;
using FightClub.Data.Enum;
using FightClub.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FightClub.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FightClubDbContext>();

                context.Database.EnsureCreated();

                // Seed Items (Market)
                if (!context.Items.Any())
                {
                    context.Items.AddRange(new List<Item>()
                    {
                        // Weapons
                        new Item { Name = "Rusty Dagger", ItemType = ItemType.Weapon, StatAttack = 3, StatDefense = 0, StatHP = 0, Price = 20, Description = "A small and worn dagger. Better than nothing, but not by much." },
                        new Item { Name = "Iron Sword", ItemType = ItemType.Weapon, StatAttack = 6, StatDefense = 0, StatHP = 0, Price = 50, Description = "Reliable iron sword, commonly used by foot soldiers." },
                        new Item { Name = "Steel Longsword", ItemType = ItemType.Weapon, StatAttack = 12, StatDefense = 2, StatHP = 0, Price = 120, Description = "Sharp longsword forged from steel. Strong and durable." },
                        new Item { Name = "Battle Axe", ItemType = ItemType.Weapon, StatAttack = 15, StatDefense = 0, StatHP = 0, Price = 180, Description = "Heavy axe capable of cleaving through armor." },
                        new Item { Name = "Elven Bow", ItemType = ItemType.Weapon, StatAttack = 10, StatDefense = 0, StatHP = 0, Price = 150, Description = "Elegant bow crafted by elves, extremely precise." },

                        // Armors
                        new Item { Name = "Leather Armor", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 5, StatHP = 10, Price = 40, Description = "Light armor made of leather. Provides minimal protection." },
                        new Item { Name = "Chainmail", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 12, StatHP = 20, Price = 100, Description = "Interlinked steel rings that protect against slashes." },
                        new Item { Name = "Steel Plate Armor", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 20, StatHP = 35, Price = 200, Description = "Heavy plate armor offering excellent protection." },
                        new Item { Name = "Knight’s Shield", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 15, StatHP = 15, Price = 150, Description = "Large shield used by knights to block powerful strikes." },
                        new Item { Name = "Dragon Scale Armor", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 30, StatHP = 50, Price = 400, Description = "Extremely rare armor forged from dragon scales." },

                        // Potions
                        new Item { Name = "Small Health Potion", ItemType = ItemType.Potion, StatAttack = 0, StatDefense = 0, StatHP = 20, Price = 15, Description = "Restores a small amount of health." },
                        new Item { Name = "Greater Health Potion", ItemType = ItemType.Potion, StatAttack = 0, StatDefense = 0, StatHP = 50, Price = 40, Description = "Restores a moderate amount of health." },
                        new Item { Name = "Major Health Potion", ItemType = ItemType.Potion, StatAttack = 0, StatDefense = 0, StatHP = 100, Price = 90, Description = "Restores a large amount of health quickly." },
                        new Item { Name = "Potion of Strength", ItemType = ItemType.Potion, StatAttack = 5, StatDefense = 0, StatHP = 0, Price = 60, Description = "Temporarily boosts attack power." },
                        new Item { Name = "Potion of Fortitude", ItemType = ItemType.Potion, StatAttack = 0, StatDefense = 5, StatHP = 0, Price = 60, Description = "Increases defense for a short duration." }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
