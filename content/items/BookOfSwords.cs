using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.content.items
{
    internal class BookOfSwords : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 2;
            Item.damage = 24;
            Item.knockBack = 3.4f;

            Item.useTime = 20;
            Item.useAnimation = 15;

            Item.UseSound = SoundID.Item71;

            Item.shoot = ModContent.ProjectileType<BookOfSwordsProjectile>();
            Item.shootSpeed = 20f;
        }
    }
}
