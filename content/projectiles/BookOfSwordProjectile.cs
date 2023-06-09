using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using MagicMod.content.items;

namespace MagicMod.content.projectiles
{
    public class BookOfSwordProjectile : ModProjectile
    {

        public bool IsStickingToTarget
        {
            get => Projectile.ai[0] == 1f;
            set => Projectile.ai[0] = value ? 1f : 0f;
        }

        public int TargetWhoAmI
        {
            get => (int)Projectile.ai[1];
            set => Projectile.ai[1] = value;
        }

        public override void SetDefaults()
        {
            Projectile.width = 52;
            Projectile.height = 52;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;

            Projectile.DamageType = DamageClass.Magic;

            Projectile.aiStyle = 0;

            Projectile.penetrate = -1;

        }

        /*        public override void AI()
                {

                    //Match roation of sprite to direction of projectile
                    float velRotation = Projectile.velocity.ToRotation();
                    Projectile.rotation = velRotation + MathHelper.ToRadians(45f);


                    Lighting.AddLight(Projectile.Center, 0.75f, 0.75f, 0.75f);
                }*/

        public override void AI()
        {
            if (IsStickingToTarget)
            {
                StickyAI();
            }
            else
            {
                NormalAI();
            }
        }

        public void NormalAI()
        {
            float velRotation = Projectile.velocity.ToRotation();
            Projectile.rotation = velRotation + MathHelper.ToRadians(45f);


            Lighting.AddLight(Projectile.Center, 0.75f, 0.75f, 0.75f);
        }

        public void StickyAI()
        {
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;

            int npcTarget = TargetWhoAmI;

            if (Main.npc[npcTarget].active && !Main.npc[npcTarget].dontTakeDamage)
            {
                Projectile.Center = Main.npc[npcTarget].Center - Projectile.velocity * 2f;
                Projectile.gfxOffY = Main.npc[npcTarget].gfxOffY;
            }
            else
            {
                Projectile.Kill();
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            IsStickingToTarget = true;
            TargetWhoAmI = target.whoAmI;
            Projectile.velocity = (target.Center - Projectile.Center) * 0.75f;
            Projectile.netUpdate = true;
            Projectile.damage = 0;

            if (Main.player[Projectile.owner].HeldItem.ModItem is BookOfSwords bookOfSwords)
            {
                if (bookOfSwords.hits.Contains(target))
                {
                    int index = bookOfSwords.hits.IndexOf(target);
                    bookOfSwords.hitNums[index]++;
                }
                else
                {
                    bookOfSwords.hits.Add(target);
                    bookOfSwords.hitNums.Add(1);
                }

                foreach (NPC npc in bookOfSwords.hits)
                {
                    Main.NewText(npc.ToString(), 255, 255, 255);
                }

                foreach (int num in bookOfSwords.hitNums)
                {
                    Main.NewText(num.ToString(), 255, 255, 255);
                }
                Main.NewText("end", 255, 255, 255);
            }
        }
    }
}
