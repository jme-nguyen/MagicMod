using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MagicMod.content.buffs
{
    public class FarmingBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            // Battle Buff (ID = 13)
            player.enemySpawns = true;

            // Hunter Buff (ID = 17)
            player.detectCreature = true;

            // Endurance Buff (ID = 114)
            player.endurance += 0.1f;

            // Greater Luck Buff (ID = 257)
            player.luckPotion = 3;

            // Ironskin Buff (ID = 5)
            player.statDefense += 8;

            // Rage Buff (ID = 115)
            player.GetCritChance(DamageClass.Generic) += 10;

            // Wrath Buff (ID = 117)
            player.GetDamage(DamageClass.Generic) += 0.1f;
        }
    }
}
