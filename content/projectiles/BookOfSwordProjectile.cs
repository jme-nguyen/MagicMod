using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MagicMod.content.projectiles
{
    internal class BookOfSwordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 52;
            Projectile.height = 48;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;

            Projectile.DamageType = DamageClass.Magic;

            Projectile.aiStyle = 0;

            Projectile.penetrate = -1;

        }

        public override void AI()
        {

            //Match roation of sprite to direction of projectile
            float velRotation = Projectile.velocity.ToRotation();
            Projectile.rotation = velRotation + MathHelper.ToRadians(45f);


            Lighting.AddLight(Projectile.Center, 0.75f, 0.75f, 0.75f);
        }
    }
}
