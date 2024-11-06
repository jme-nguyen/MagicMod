using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using MagicMod.content.buffs;
using MagicMod.content.projectiles;

namespace MagicMod.content.globalNPCs
{
    internal class DamageOverTimeGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool bookOfSwordsDebuff;

        public override void ResetEffects(NPC npc)
        {
            bookOfSwordsDebuff = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (bookOfSwordsDebuff)
            {

            }
        }
    }
}
