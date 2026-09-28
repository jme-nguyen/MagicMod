using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.content.items
{
    public class AnglerBuffPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(240, 240, 240),
                new Color(200, 200, 200),
                new Color(140, 140, 140)
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
            Item.value = Item.buyPrice(gold: 2);
            Item.buffType = ModContent.BuffType<buffs.AnglerBuff>(); // Specify an existing buff to be applied when used.
            Item.buffTime = 8 * 60 * 60; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
        public override void AddRecipes()
        {
            //Potion can be crafted at bottle or alchemy table with three recipes below, buff time is 8 minutes
            Recipe recipe1 = CreateRecipe(1);
            recipe1.AddIngredient(ItemID.CratePotion, 1);
            recipe1.AddIngredient(ItemID.GoldCoin, 1);

            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddIngredient(ItemID.FishingPotion, 1);
            recipe1.AddIngredient(ItemID.GoldCoin, 1);

            Recipe recipe3 = CreateRecipe(1);
            recipe3.AddIngredient(ItemID.SonarPotion, 1);
            recipe1.AddIngredient(ItemID.GoldCoin, 1);

            recipe1.AddTile(TileID.Bottles);
            recipe1.AddTile(TileID.AlchemyTable);

            recipe2.AddTile(TileID.Bottles);
            recipe2.AddTile(TileID.AlchemyTable);

            recipe3.AddTile(TileID.Bottles);
            recipe3.AddTile(TileID.AlchemyTable);

            recipe1.Register();
            recipe2.Register();
            recipe3.Register();
        }
    }
}
