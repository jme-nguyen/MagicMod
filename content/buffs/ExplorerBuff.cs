using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MagicMod.content.buffs
{
    public class ExplorerBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            // Dangersense Buff (ID = 111)
            player.dangerSense = true;

            // Featherfall Buff (ID = 8)
            player.slowFall = true;

            // Flipper Buff (ID = 109)
            player.ignoreWater = true;
            player.accFlipper = true;

            // Gills Buff (ID = 4)
            player.gills = true;

            // Mining Buff (ID = 104)
            player.pickSpeed -= 0.25f;

            // Night Owl Buff (ID = 12)
            player.nightVision = true;

            // Shine Buff (ID = 11)
            Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);

            // Spelunker Buff (ID = 9)
            player.findTreasure = true;
        }
    }
}
