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
                        new Item()
                        {
                            Name = "Iron Sword",
                            ItemType = ItemType.Weapon,
                            StatAttack = 10,
                            Price = 100
                        },
                        new Item()
                        {
                            Name = "Steel Axe",
                            ItemType = ItemType.Weapon,
                            StatAttack = 15,
                            Price = 200
                        },
                        new Item()
                        {
                            Name = "Long Bow",
                            ItemType = ItemType.Weapon,
                            StatAttack = 12,
                            Price = 180
                        },

                        // Armors
                        new Item()
                        {
                            Name = "Leather Armor",
                            ItemType = ItemType.Armor,
                            StatDefense = 5,
                            StatHP = 20,
                            Price = 150
                        },
                        new Item()
                        {
                            Name = "Iron Shield",
                            ItemType = ItemType.Armor,
                            StatDefense = 10,
                            StatHP = 30,
                            Price = 250
                        },
                        new Item()
                        {
                            Name = "Steel Plate",
                            ItemType = ItemType.Armor,
                            StatDefense = 20,
                            StatHP = 50,
                            Price = 400
                        },

                        // Potions
                        new Item()
                        {
                            Name = "Small Health Potion",
                            ItemType = ItemType.Potion,
                            StatHP = 50,
                            Price = 50
                        },
                        new Item()
                        {
                            Name = "Large Health Potion",
                            ItemType = ItemType.Potion,
                            StatHP = 150,
                            Price = 120
                        },
                        new Item()
                        {
                            Name = "Elixir of Strength",
                            ItemType = ItemType.Potion,
                            StatAttack = 5,
                            Price = 200
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
