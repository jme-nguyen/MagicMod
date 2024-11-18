using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MagicMod.content.buffs
{
    public class MageBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            // Exquisitely Stuffed Buffs (ID = 207)
            player.wellFed = true;
            player.statDefense += 4;
            player.GetCritChance(DamageClass.Generic) += 4;
            player.GetDamage(DamageClass.Generic) += 0.1f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
            player.GetKnockback(DamageClass.Summon).Base += 1f;
            player.moveSpeed += 0.4f;
            player.pickSpeed -= 0.15f;

            // Endurance Buff (ID = 114)
            player.endurance += 0.1f;

            // Iron Skin Buff (ID = 5)
            player.statDefense += 8;

            // Life Force Buff (ID = 113)
            player.lifeForce = true;
            player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;

            // Rage Buff (ID = 115)
            player.GetCritChance(DamageClass.Generic) += 10;

            // Regeneration Buff (ID = 2)
            player.lifeRegen += 4;

            // Swifteness Buff (ID = 3)
            player.moveSpeed += 0.25f;

            // Thorns Buff (ID = 14)
            if (player.thorns < 1f)
            {
                player.thorns = 1f;
            }

            // Wrath Buff (ID = 117)
            player.GetDamage(DamageClass.Generic) += 0.1f;

            // Magic Power Buff (ID = 7)
            player.GetDamage(DamageClass.Magic) += 0.2f;

            // Mana Regeneration Buff (ID = 6)
            player.manaRegenBuff = true;
        }
    }
}
