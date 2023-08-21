using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Enemy Factory and spawner
    /// </summary>
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Path[] paths;
        [SerializeField] private Transform[] spawnPoints;
        private EnemyCollection enemyCollection;
        private List<Wave> waves;

        public bool IsSpawning { get; private set; }
        
        public void SetUp(EnemyCollection enemies)
        {
            enemyCollection = enemies;
            waves = new List<Wave>();
            IsSpawning = false;
        }

        public void AddWave(Wave wave)
        {
            waves.Add(wave);
        }

        public void StartSpawning()
        {
            IsSpawning = true;
            foreach (var wave in waves)
            {
                StartCoroutine(SpawnWave(wave));
            }
        }
        public void Stop()
        {
            IsSpawning = false;
        }

        private void Spawn(int id)
        {
            var enemy = enemyCollection.Build(id, transform.position, Quaternion.identity);
            enemy.transform.position = spawnPoints[(int)enemy.Stats.enemyType].position;
            enemy.motor.SetNavigationStrategy(paths[(int)enemy.Stats.enemyType]);
        }

        private IEnumerator SpawnWave(Wave wave)
        {
            yield return new WaitForSeconds(wave.waveDelay);
            foreach (var item in wave.prefabIndices)
            {
                Spawn(item);

                if (!IsSpawning)
                    yield break;
                
                yield return new WaitForSeconds(wave.delay);
            }
        }
    }
}