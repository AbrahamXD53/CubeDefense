using CubeDefense;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense {

    /// <summary>
    /// Turret description, to build and control stats
    /// </summary>
    [System.Serializable]
    public class TurretDescription
    {
        public Turret prefab;
        public Vector3 offset;
        public Sprite sprite;
        public int price;

        public ProjectileType projectileType;
        public LayerMask layerMask;

        public List<TurretStats> levels;
    }

}