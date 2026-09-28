using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MagicMod.content.buffs
{
    public class AnglerBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //ign Fishy Potion, combines effects of crate, fishing, sonar, waterwalking

            // Crate Buff (ID = 123)
            player.cratePotion = true;

            // Fishing Buff (ID = 121)
            player.fishingSkill += 15;

            // Sonar Buff (ID = 122)
            player.sonarPotion = true;

            //WaterWalking Buff (ID = 15)
            player.waterWalk = true;
        }
    }
}
