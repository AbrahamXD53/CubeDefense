using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    public class BaseProjectile : AProjectileCollision
    {
        public override ProjectileType projectileType => ProjectileType.Base;
        public override void Collided(Projectile projectile, Enemy enemy)
        {
            enemy.damageable.TakeDamage(projectile.Stats.damage);
            projectile.Release();
        }
    }
}