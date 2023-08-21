using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense {
    public class ExplosiveProjectile : AProjectileCollision
    {
        //Default mask layer for enemies
        private const int LayerMask = 192;

        private Collider[] colliders;

        public override ProjectileType projectileType => ProjectileType.Explosive;
        public override void Collided(Projectile projectile, Enemy enemy)
        {
            colliders = Physics.OverlapSphere(projectile.transform.position, projectile.Stats.damage, LayerMask);
            if(colliders.Length<1)
                return;

            foreach (var col in colliders)
            {
                var e = col.GetComponent<EnemyDamageable>();
                if (!e)
                    continue;

                e.TakeDamage(projectile.Stats.damage);
            }
            
            AudioManager.Instance.PlaySfx(AudioManager.CIdExplosion);

            projectile.Release();
        }
    }
}
