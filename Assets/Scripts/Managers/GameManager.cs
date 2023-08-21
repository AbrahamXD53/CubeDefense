using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

namespace CubeDefense
{
    /// <summary>
    /// General GameManager, public static reference available through Instance member
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Local Objects")]
        [SerializeField] private ProjectileManager projectileManager;
        [SerializeField] private SpawnManager spawnManager;
        [SerializeField] private Shop shop;

        [Header("Settings")]
        [SerializeField] private EnemyCollection enemies;
        [SerializeField] private TurretCollection collection;
        [SerializeField] private LevelWave level;

        public GameState State { get; private set; }

        [Header("Events")]
        public UnityEvent OnMoneyUpdated;
        public UnityEvent OnEnemyCountUpdated;
        public UnityEvent OnLivesUpdated;

        public UnityEvent OnGameOver;
        public UnityEvent OnGameWon;
        public UnityEvent OnGameStart;

        private void Awake()
        {
            Instance = this;

            State = new GameState();
            State.lives = level.lives;
            State.totalEnemies = level.TotalEnemies;
        }

        void Start()
        {
            AudioManager.Instance.PlayBackground(level.songId);

            shop.SetUp(collection, level.startingMoney);
            spawnManager.SetUp(enemies, level.waves);

            OnGameOver.AddListener(spawnManager.StopSpawners);
            OnGameWon.AddListener(spawnManager.StopSpawners);
            OnGameStart.AddListener(spawnManager.StartSpawn);

            StartCoroutine(StartGame());
        }

        public void CreateTurret(TurretTile turretTile, TurretDescription description)
        {
            Turret turret = Instantiate(description.prefab, turretTile.transform.position + description.offset, Quaternion.identity);
            turret.SetUp(turretTile, description, projectileManager);

            AudioManager.Instance.PlaySfx(AudioManager.CIdBuild);

            shop.UpdateMoney(-description.price);
        }

        public void EnemyKilled(Enemy enemy)
        {
            if (State.isGameOver)
                return;

            State.enemyCount++;

            OnEnemyCountUpdated.Invoke();
            OnMoneyUpdated.Invoke();

            AudioManager.Instance.PlaySfx(AudioManager.CIdDead);

            shop.UpdateMoney(enemy.Stats.worth);

            CheckEnemyCount();
        }

        public void EnemyDamage()
        {
            if (State.isGameOver)
                return;

            State.enemyCount++;
            State.lives--;

            AudioManager.Instance.PlaySfx(AudioManager.CIdLostLife);
            
            OnEnemyCountUpdated.Invoke();
            OnLivesUpdated.Invoke();

            if (State.IsGameLost)
            {
                State.isGameOver = true;
                OnGameOver.Invoke();
            }
            else
            {
                CheckEnemyCount();
            }
        }

        private void CheckEnemyCount() {
            if (State.isGameOver)
                return;

            if (State.IsGameWin)
            {
                State.isGameOver = true;
                OnGameWon.Invoke();
            }
        }

        private IEnumerator StartGame()
        {
            yield return new WaitForSeconds(level.prepTime);
            OnGameStart.Invoke();
        }
    }

}