using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.content.items
{
    public class MeleeBuffPotion : ModItem
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
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 1);
            Item.buffType = ModContent.BuffType<buffs.MeleeBuff>(); // Specify an existing buff to be applied when used.
            Item.buffTime = 36000; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
        public override void AddRecipes()
        {
            RecipeGroup ExquisitelyStuffedGroup = new RecipeGroup(
                () => $"Any Exquisitely Stuffed Food",
                ItemID.GoldenDelight,
                ItemID.Bacon,
                ItemID.BBQRibs,
                ItemID.Burger,
                ItemID.Milkshake,
                ItemID.Pizza,
                ItemID.Spaghetti,
                ItemID.Steak,
                ItemID.ChristmasPudding,
                ItemID.GingerbreadCookie,
                ItemID.SugarCookie,
                ItemID.ApplePie,
                ItemID.GrapeJuice);

            RecipeGroup.RegisterGroup("ExquisitelyStuffedFoods", ExquisitelyStuffedGroup);

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.EndurancePotion, 1);
            recipe.AddIngredient(ItemID.IronskinPotion, 1);
            recipe.AddIngredient(ItemID.LifeforcePotion, 1);
            recipe.AddIngredient(ItemID.RagePotion, 1);
            recipe.AddIngredient(ItemID.RegenerationPotion, 1);
            recipe.AddIngredient(ItemID.SwiftnessPotion, 1);
            recipe.AddIngredient(ItemID.ThornsPotion, 1);
            recipe.AddIngredient(ItemID.TitanPotion, 1);
            recipe.AddIngredient(ItemID.WrathPotion, 1);
            recipe.AddRecipeGroup("ExquisitelyStuffedFoods", 1);
            recipe.AddTile(TileID.Bottles);

            recipe.Register();
        }
    }
}
