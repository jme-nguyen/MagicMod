using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MagicMod.content.buffs
{
    public class ArchitectBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            // Building Buff (ID = 107)
            player.tileSpeed += 0.25f;
            player.wallSpeed += 0.25f;
            player.blockRange++;

            // Biome Sight Buff (ID = 343)
            player.biomeSight = true;

            // Calming Buff (ID = 106)
            player.calmed = true;

            // Mining Buff (ID = 104)
            player.pickSpeed -= 0.25f;

            // Shine Buff (ID = 11)
            Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
        }
    }
}
