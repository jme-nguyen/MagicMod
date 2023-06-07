using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.content.projectiles
{
    internal class BookOfSwordProjectile : ModProjectile
    {
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

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 0.75f, 0.75f, 0.75f);
        }
    }
}
