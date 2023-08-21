using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    public class IceProjectile : AProjectileCollision
    {
        private RaycastHit[] raycastHits;
        public override ProjectileType projectileType => ProjectileType.Ice;
        public override void Collided(Projectile projectile, Enemy enemy)
        {
            enemy.motor.SlowIt(0.9f);
            enemy.damageable.TakeDamage(projectile.Stats.damage);

            AudioManager.Instance.PlaySfx(AudioManager.CIdIce);
            projectile.Release();
        }
    }
}
