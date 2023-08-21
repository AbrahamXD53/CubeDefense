using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CubeDefense
{
    /// <summary>
    /// MonoBehaviour implementation of IDamageable
    /// </summary>
    public class EnemyDamageable : MonoBehaviour, IDamageable
    {
        #region Damageable
        public int Health { get; set; }
        public bool IsDead { get; set; }

        [field: SerializeField]
        public HealthBar LifeBar { get; set; }
        #endregion

        private int maxHealth;
        public UnityAction OnKilled;

        public void TakeDamage(int damage)
        {
            Health -= damage;
            LifeBar.UpdateFill(Health / (float)maxHealth);

            if (Health <= 0 && !IsDead)
            {
                IsDead = true;
                Kill();
            }
        }

        public void Kill()
        {
            OnKilled?.Invoke();
        }

        public void AlignCamera()
        {
            LifeBar.AlignCamera();
        }

        public void SetUp(int maximunHealth)
        {
            IsDead = false;
            maxHealth = maximunHealth;
            Health = maximunHealth;

            LifeBar.AlignCamera();
            LifeBar.UpdateFill(Health / maxHealth);
        }
    }
}