using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using MagicMod.content.projectiles;
using System.Collections.Generic;
using MagicMod.content.buffs;

namespace MagicMod.content.items
{
    public class BookOfSwords : ModItem
    {
        public List<NPC> hits = new List<NPC>();
        public List<int> hitNums = new List<int>();
        public List<List<Projectile>> projectilelist = new List<List<Projectile>>();
        private const int damageMult = 24;

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 2;
            Item.damage = 1;
            Item.knockBack = 3.4f;

            Item.useTime = 20;
            Item.useAnimation = 15;

            Item.UseSound = SoundID.Item71;

            Item.shoot = ModContent.ProjectileType<BookOfSwordProjectile>();
            Item.shootSpeed = 20f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Book);
            if (ModLoader.TryGetMod("AerialiteBar", out Mod calamityMod) && calamityMod.TryFind<ModItem>("AerialiteBar", out ModItem AerialiteBar))
            {
                recipe.AddIngredient(AerialiteBar);
            }
            else
            {
                recipe.AddIngredient(ItemID.Feather, 300);
            }
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.width = 28;
                Item.height = 28;
                Item.useStyle = ItemUseStyleID.Shoot;

                Item.noMelee = true;
                Item.damage = 0;
                Item.mana = 0;
                Item.shoot = ProjectileID.None;
                Item.UseSound = SoundID.Item1;

                Item.useTime = 20;
                Item.useAnimation = 15;

                for (int i = 0; i < hits.Count; i++)
                {
                    double totalDam = 0;

                    double numOfHits = hitNums[i];
                    if (numOfHits > 10)
                    {
                        totalDam = numOfHits * damageMult * 1.1;
                    }
                    else
                    {
                        totalDam = numOfHits * damageMult;
                    }


                    NPC enemy = hits[i];
                    foreach (Projectile projectile in projectilelist[i])
                    {
                        projectile.Kill();
                    }

                    int hitDirection = player.Center.X < enemy.Center.X ? 1 : -1;

                    enemy.StrikeNPC(new NPC.HitInfo
                    {
                        Damage = (int)totalDam,
                        Knockback = Item.knockBack,
                        HitDirection = hitDirection,
                    });
                }

            }
            else
            {
                Item.width = 28;
                Item.height = 28;
                Item.useStyle = ItemUseStyleID.Shoot;

                Item.DamageType = DamageClass.Magic;
                Item.noMelee = true;
                Item.mana = 2;
                Item.damage = 1;
                Item.knockBack = 3.4f;

                Item.useTime = 20;
                Item.useAnimation = 15;

                Item.UseSound = SoundID.Item71;

                Item.shoot = ModContent.ProjectileType<BookOfSwordProjectile>();
                Item.shootSpeed = 20f;
            }
            return true;
        }
    }
}
