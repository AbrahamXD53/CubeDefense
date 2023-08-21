using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Base Enemy class
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        /// <summary>
        /// Enemy stats are assigned at rutime
        /// </summary>
        public EnemyStats Stats { get; set; }

        public EnemyMover motor;
        public EnemyDamageable damageable;

        private void Awake()
        {
            damageable.OnKilled = OnEnemieKilled;
            motor.OnPathUpdated = damageable.AlignCamera;
            motor.OnPathCompleted = OnPathCompleted;
        }

        private void OnPathCompleted()
        {
            GameManager.Instance.EnemyDamage();
            Destroy(gameObject);
        }

        private void OnEnemieKilled()
        {
            GameManager.Instance.EnemyKilled(this);
            Destroy(gameObject);
        }

        public void SetStats(EnemyStats enemyStats)
        {
            Stats = enemyStats;

            damageable.SetUp(Stats.health);
            motor.SetUp(Stats.speed);
        }



    }
}
