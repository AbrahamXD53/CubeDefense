using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    public enum ProjectileType
    {
        /// <summary>
        /// Base projectile type, no special effects, see <see cref="BaseProjectile"/>
        /// </summary>
        Base,
        /// <summary>
        /// Ice projectile type, freezes enemies, see <see cref="IceProjectile"/>
        /// </summary>
        Ice,
        /// <summary>
        /// Explosive projectile type, explodes enemies around, see <see cref="ExplosiveProjectile"/>
        /// </summary>
        Explosive
    }
}
