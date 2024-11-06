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
            Projectile.width = 28;
            Projectile.height = 28;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;

            Projectile.DamageType = DamageClass.Magic;

            Projectile.aiStyle = 0;

            Projectile.penetrate = -1;

        }

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
            //Match roation of sprite to direction of projectile
            float velRotation = Projectile.velocity.ToRotation();
            Projectile.rotation = velRotation + MathHelper.ToRadians(270f);


            Lighting.AddLight(Projectile.Center, 0.75f, 0.75f, 0.75f);
        }

        public void StickyAI()
        {
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;

            int npcTarget = TargetWhoAmI;

            if (Main.npc[npcTarget].active && !Main.npc[npcTarget].dontTakeDamage)
            {
                Projectile.Center = Main.npc[npcTarget].Center - Projectile.velocity * 2.5f;
                Projectile.gfxOffY = Main.npc[npcTarget].gfxOffY;
            }
            else
            {
                Projectile.Kill();
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
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
                    bookOfSwords.projectilelist[index].Add(Projectile);
                }
                else
                {
                    bookOfSwords.hits.Add(target);
                    bookOfSwords.hitNums.Add(1);
                    List<Projectile> tempList = new List<Projectile>
                    {
                        Projectile
                    };
                    bookOfSwords.projectilelist.Add(tempList);
                }
            }
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            // By shrinking target hitboxes by a small amount, this projectile only hits if it more directly hits the target.
            // This helps the javelin stick in a visually appealing place within the target sprite.
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            // Return if the hitboxes intersects, which means the javelin collides or not
            return projHitbox.Intersects(targetHitbox);
        }
    }
}
