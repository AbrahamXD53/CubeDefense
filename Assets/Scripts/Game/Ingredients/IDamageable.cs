using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Interface to be implemented when an object can have a <see cref="LifeBar"/> and die
    /// </summary>
    public interface IDamageable
    {
        public HealthBar LifeBar { get; set; }
        public int Health { get; set; }
        public bool IsDead { get; set; }
        public void TakeDamage(int damage);

        public void Kill();
    }

}
