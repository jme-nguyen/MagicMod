using Terraria;
using Terraria.ModLoader;
using MagicMod.content.globalNPCs;

namespace MagicMod.content.buffs
{
    public class BookOfSwordsDebuff : ModBuff
    {
        public Player playerCalled;

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<DamageOverTimeGlobalNPC>().bookOfSwordsDebuff = true;
        }
    }
}
