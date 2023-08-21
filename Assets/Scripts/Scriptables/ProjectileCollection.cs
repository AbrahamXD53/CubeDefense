using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CubeDefense
{
    /// <summary>
    /// ScriptableObject to set different projectile stats
    /// </summary>
    [CreateAssetMenu(fileName = "Projectile Collection", menuName = "Collections/Projectiles")]
    public class ProjectileCollection : ScriptableObject
    {
        public Projectile projPrefab;
        public ProjectileStats[] projectileStats;
    }
}