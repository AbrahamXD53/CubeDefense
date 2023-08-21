using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    [System.Serializable]
    public class GameState
    {
        public int lives;
        public int enemyCount;
        public int totalEnemies;
        public bool isGameOver;

        public bool IsGameLost { get => lives <= 0; }
        public bool IsGameWin { get => enemyCount >= totalEnemies; }
    }
}
