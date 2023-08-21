using CubeDefense;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Scriptable object with references to <see cref="Enemy"/> prefabs and their <see cref="EnemyStats"/>
    /// </summary>
    [CreateAssetMenu(fileName = "Enemy Collection", menuName = "Collections/Enemies")]

    public class EnemyCollection : ScriptableObject
    {
        public List<Enemy> enemies;
        public List<EnemyStats> stats;

        public Enemy Build(int id, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            var e = Instantiate(enemies[id], position, rotation, parent);
            e.SetStats(stats[id]);

            return e;
        }
    }
}
