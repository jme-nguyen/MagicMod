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
            Projectile.width = 16;
            Projectile.height = 16;
 
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
                NPC npc = Main.npc[npcTarget];

                // Direction is already stored in velocity from OnHitNPC
                Vector2 direction = Projectile.velocity;

                // Calculate offset based on NPC and projectile sizes
                float offsetDistance = (npc.width + npc.height) / 5f + Projectile.width / 2f;

                // Position the projectile on the surface
                Projectile.Center = npc.Center + (direction * offsetDistance);

                // Update rotation
                Projectile.rotation = direction.ToRotation() + MathHelper.ToRadians(90f);

                Projectile.gfxOffY = npc.gfxOffY;
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

            // Store the direction FROM projectile TO target (reversed from current)
            Projectile.velocity = (Projectile.Center - target.Center).SafeNormalize(Vector2.Zero);

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
                targetHitbox.Inflate(-targetHitbox.Width / 6, -targetHitbox.Height / 6);
            }
            // Return if the hitboxes intersects, which means the javelin collides or not
            return projHitbox.Intersects(targetHitbox);
        }
    }
}
