using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MagicMod.content.buffs
{
    public class BattleBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //example add buff from existing vanilla game: player.AddBuff(BuffID.exampleBuff, duration of buff in ticks)

            player.ammoPotion = true;
            player.archery = true;
            player.dangerSense = true;
            player.endurance += 0.1f;
            player.lifeMagnet = true;
            player.detectCreature = true;
            player.statDefense += 8;
            player.lifeForce = true;
            player.GetDamage(DamageClass.Magic) += 0.2f;
            player.manaRegenBuff = true;
            player.nightVision = true;
            player.GetCritChance(DamageClass.Generic) += 10f;
            player.lifeRegen += 4;
            player.maxMinions += 1;
            player.moveSpeed += 0.25f;
            player.AddBuff(BuffID.Thorns, 60 * 60 * 10);
            player.GetKnockback(DamageClass.Generic) += 0.5f;
            player.GetDamage(DamageClass.Generic) += 0.1f;
        }
    }
}
