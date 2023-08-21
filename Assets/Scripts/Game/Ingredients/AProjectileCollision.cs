using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Projectile collision resolver
    /// </summary>
    public abstract class AProjectileCollision
    {
        public virtual ProjectileType projectileType { get; }
        public abstract void Collided(Projectile projectile, Enemy enemy);

    }

}
