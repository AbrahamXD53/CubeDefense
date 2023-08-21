using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    [System.Serializable]
    public class EnemyStats
    {
        [Range(0.1f, 10)]
        public float speed;
        [Range(30, 200)]
        public int health;

        /// <summary>
        /// How much money will be granted when it dies by projectiles
        /// </summary>
        [Range(10, 100)]
        public int worth;

        public EnemyType enemyType;
    }
}

