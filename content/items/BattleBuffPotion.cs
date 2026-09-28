using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.content.items
{
    internal class BattleBuffPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 10;

            // Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(242, 116, 65),
                new Color(242, 95, 65),
                new Color(242, 148, 65)
            };
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(gold: 10);
            Item.buffType = ModContent.BuffType<buffs.BattleBuff>(); // Specify an existing buff to be applied when used.
            Item.buffTime = 10 * 60 * 60; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe(8);

            recipe1.AddIngredient(ItemID.HealingPotion, 1);
            recipe1.AddIngredient(ItemID.GoldCoin, 1);
            recipe1.AddIngredient(ItemID.Cactus, 1);

            recipe1.AddTile(TileID.Bottles);
            recipe1.AddTile(TileID.AlchemyTable);

            recipe1.Register();
        }
    }
}
