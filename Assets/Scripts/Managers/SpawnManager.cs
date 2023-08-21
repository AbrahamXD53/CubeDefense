using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Spawn manager that handles all spawners in scene
    /// </summary>
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Spawner[] spawners;
        private EnemyCollection enemies;
        private List<Wave> waves;

        public void SetUp(EnemyCollection enemyCollection, List<Wave> waveList)
        {
            enemies = enemyCollection;
            waves = waveList;

            foreach (var spawner in spawners)
            {
                spawner.SetUp(enemies);
            }
            foreach (var wave in waves)
            {
                spawners[wave.spawner].AddWave(wave);
            }
        }

        public void StopSpawners()
        {
            foreach (var spawner in spawners)
            {
                spawner.Stop();
            }
        }

        public void StartSpawn()
        {
            foreach (var spawner in spawners)
            {
                spawner.StartSpawning();
            }
        }
    }
}