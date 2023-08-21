using System.Collections.Generic;

namespace CubeDefense
{
    [System.Serializable]
    public class Wave
    {
        /// <summary>
        /// Indices of prefabs in collection to be spawned
        /// </summary>
        public List<int> prefabIndices = new List<int>();

        /// <summary>
        /// Delay between spawns
        /// </summary>
        public float delay;

        /// <summary>
        /// Selected spawner in scene
        /// </summary>
        public int spawner;

        /// <summary>
        /// Delay before wave start
        /// </summary>
        public float waveDelay;
    }
}