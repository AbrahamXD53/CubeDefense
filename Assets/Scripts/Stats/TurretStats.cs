using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    [System.Serializable]
    public class TurretStats
    {
        [Range(1.0f, 20.0f)]
        public float range;

        [Range(0.1f, 5f)]
        public float fireRate;
    }
}
