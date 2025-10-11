using FightClub.Data;
using FightClub.Models;
using FightClub.Data.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
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

                if (!context.Items.Any())
                {
                    context.Items.AddRange(new List<Item>
                    {
                        // --- HUMAN ---
                        new Item { Name = "Knight’s Blade", ItemType = ItemType.Weapon, StatAttack = 12, StatDefense = 2, StatHP = 0, Price = 150, Description = "A finely forged longsword used by royal knights." },
                        new Item { Name = "Paladin’s Mace", ItemType = ItemType.Weapon, StatAttack = 10, StatDefense = 4, StatHP = 0, Price = 140, Description = "A heavy mace used by holy warriors to smite evil." },

                        new Item { Name = "Steel Armor", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 20, StatHP = 30, Price = 200, Description = "Thick steel armor favored by human soldiers." },
                        new Item { Name = "Guardian Shield", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 15, StatHP = 20, Price = 160, Description = "A durable shield that blocks even the hardest blows." },

                        new Item { Name = "Potion of Courage", ItemType = ItemType.Potion, StatAttack = 5, StatDefense = 0, StatHP = 0, Price = 60, Description = "Increases bravery and attack power for a short time." },
                        new Item { Name = "Elixir of Endurance", ItemType = ItemType.Potion, StatAttack = 0, StatDefense = 5, StatHP = 30, Price = 80, Description = "Restores stamina and boosts resilience." },

                        // --- ELF ---
                        new Item { Name = "Elven Bow", ItemType = ItemType.Weapon, StatAttack = 14, StatDefense = 0, StatHP = 0, Price = 180, Description = "Elegant bow crafted from ancient elven wood." },
                        new Item { Name = "Forest Dagger", ItemType = ItemType.Weapon, StatAttack = 10, StatDefense = 1, StatHP = 0, Price = 120, Description = "A swift dagger used by elven scouts." },

                        new Item { Name = "Ranger Cloak", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 10, StatHP = 15, Price = 120, Description = "A lightweight cloak offering natural camouflage." },
                        new Item { Name = "Silverleaf Armor", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 14, StatHP = 25, Price = 160, Description = "Flexible armor made from enchanted leaves." },

                        new Item { Name = "Elven Nectar", ItemType = ItemType.Potion, StatAttack = 0, StatDefense = 0, StatHP = 40, Price = 50, Description = "A healing potion brewed from rare forest herbs." },
                        new Item { Name = "Brew of Precision", ItemType = ItemType.Potion, StatAttack = 8, StatDefense = 0, StatHP = 0, Price = 70, Description = "Sharpens senses, increasing ranged accuracy." },

                        // --- ORC ---
                        new Item { Name = "War Axe", ItemType = ItemType.Weapon, StatAttack = 16, StatDefense = 0, StatHP = 0, Price = 190, Description = "Massive axe capable of cleaving through armor." },
                        new Item { Name = "Spiked Club", ItemType = ItemType.Weapon, StatAttack = 13, StatDefense = 1, StatHP = 0, Price = 140, Description = "A crude but deadly club with iron spikes." },

                        new Item { Name = "Bone Chestplate", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 18, StatHP = 25, Price = 170, Description = "Armor made of thick bones from fallen beasts." },
                        new Item { Name = "Warlord Helm", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 10, StatHP = 15, Price = 120, Description = "A skull-like helmet that inspires fear." },

                        new Item { Name = "Rage Brew", ItemType = ItemType.Potion, StatAttack = 10, StatDefense = -2, StatHP = 0, Price = 80, Description = "Increases strength but lowers defense temporarily." },
                        new Item { Name = "Blood Draught", ItemType = ItemType.Potion, StatAttack = 0, StatDefense = 0, StatHP = 50, Price = 70, Description = "Restores health with a rush of fury." },

                        // --- DWARF ---
                        new Item { Name = "Warhammer", ItemType = ItemType.Weapon, StatAttack = 15, StatDefense = 2, StatHP = 0, Price = 180, Description = "A powerful hammer forged in the deepest mines." },
                        new Item { Name = "Rune Axe", ItemType = ItemType.Weapon, StatAttack = 13, StatDefense = 3, StatHP = 0, Price = 170, Description = "Axe engraved with ancient protective runes." },

                        new Item { Name = "Ironforge Armor", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 22, StatHP = 30, Price = 210, Description = "Heavy dwarven armor known for durability." },
                        new Item { Name = "Defender’s Helm", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 15, StatHP = 20, Price = 160, Description = "Helmet of those who guard the Dwarven halls." },

                        new Item { Name = "Stonebrew Ale", ItemType = ItemType.Potion, StatAttack = 0, StatDefense = 5, StatHP = 20, Price = 50, Description = "Thick dwarven brew that toughens the drinker." },
                        new Item { Name = "Molten Mead", ItemType = ItemType.Potion, StatAttack = 6, StatDefense = 0, StatHP = 0, Price = 60, Description = "Spicy drink that ignites fighting spirit." },

                        // --- UNDEAD ---
                        new Item { Name = "Soulreaper Scythe", ItemType = ItemType.Weapon, StatAttack = 17, StatDefense = 0, StatHP = 0, Price = 200, Description = "A cursed scythe that steals life from its victims." },
                        new Item { Name = "Bone Dagger", ItemType = ItemType.Weapon, StatAttack = 11, StatDefense = 1, StatHP = 0, Price = 130, Description = "Dagger carved from the bones of the fallen." },

                        new Item { Name = "Crypt Armor", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 16, StatHP = 20, Price = 150, Description = "Dark armor reeking of ancient tombs." },
                        new Item { Name = "Ghoul’s Shroud", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 10, StatHP = 15, Price = 110, Description = "A ragged shroud that absorbs some damage." },

                        new Item { Name = "Essence of Decay", ItemType = ItemType.Potion, StatAttack = 7, StatDefense = 0, StatHP = -10, Price = 70, Description = "Increases damage at the cost of vitality." },
                        new Item { Name = "Vial of Shadows", ItemType = ItemType.Potion, StatAttack = 0, StatDefense = 0, StatHP = 40, Price = 60, Description = "Restores life force from the dark." },

                        // --- DEMON ---
                        new Item { Name = "Hellblade", ItemType = ItemType.Weapon, StatAttack = 20, StatDefense = 0, StatHP = 0, Price = 220, Description = "Forged in the fires of hell, burns its victims." },
                        new Item { Name = "Infernal Claws", ItemType = ItemType.Weapon, StatAttack = 18, StatDefense = 2, StatHP = 0, Price = 200, Description = "Fiery claws that tear through flesh." },

                        new Item { Name = "Doom Armor", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 25, StatHP = 40, Price = 240, Description = "Armor of the demon lords, radiates dark energy." },
                        new Item { Name = "Ashen Pauldrons", ItemType = ItemType.Armor, StatAttack = 0, StatDefense = 15, StatHP = 20, Price = 160, Description = "Smoldering pauldrons that deflect holy attacks." },

                        new Item { Name = "Flame Elixir", ItemType = ItemType.Potion, StatAttack = 8, StatDefense = 0, StatHP = 0, Price = 60, Description = "Burns through weakness, empowering attacks." },
                        new Item { Name = "Soulfire Brew", ItemType = ItemType.Potion, StatAttack = 0, StatDefense = 5, StatHP = 30, Price = 80, Description = "Infuses the drinker with demonic vitality." }
                    });

                    context.SaveChanges();
                }

            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Create roles if they don't exist
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Player>>();

            // Admin user
            string adminEmail = "safchik9@gmail.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new Player
                {
                    UserName = "safchik",
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminUser, "Coding@1234?");
                await userManager.AddToRoleAsync(adminUser, UserRoles.Admin);
            }

            // Normal user
            string normalEmail = "user@fightclub.com";
            if (await userManager.FindByEmailAsync(normalEmail) == null)
            {
                var normalUser = new Player
                {
                    UserName = "app-user",
                    Email = normalEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(normalUser, "Coding@1234?");
                await userManager.AddToRoleAsync(normalUser, UserRoles.User);
            }
        }

    }
}
