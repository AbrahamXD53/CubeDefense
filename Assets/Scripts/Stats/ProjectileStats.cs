using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense {

    /// <summary>
    /// Projectile stats to be used in collisions and when pooling at Factory <see cref="ProjectileManager"/>
    /// </summary>
    [System.Serializable]
    public class ProjectileStats
    {
        public ProjectileType projectileType;
        public Material material;
        public int damage;
        public float speed;

        public GameObject collisionPrefab;
    }
}