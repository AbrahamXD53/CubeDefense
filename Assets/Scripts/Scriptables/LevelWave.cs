using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Level Settings
    /// </summary>
    [CreateAssetMenu(fileName = "Level", menuName = "Level/Waves")]
    public class LevelWave : ScriptableObject
    {
        [Range(1f, 100f)]
        public int lives;
        public int startingMoney;
        public float prepTime;
        public int songId;

        public List<Wave> waves;
        public int TotalEnemies { get => waves.Sum(w => w.prefabIndices.Count); } 
    }
}