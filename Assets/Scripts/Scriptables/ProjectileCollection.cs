using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CubeDefense
{
    /// <summary>
    /// Set Projectile collection
    /// </summary>
    [CreateAssetMenu(fileName = "Projectile Collection", menuName = "Collections/Projectiles")]
    public class ProjectileCollection : ScriptableObject
    {
        public Projectile projPrefab;
        public ProjectileStats[] projectileStats;
    }
}