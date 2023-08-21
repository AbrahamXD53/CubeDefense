using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubeDefense
{
    /// <summary>
    /// Class to handle GameState changes and show'em in the UI
    /// </summary>
    public class GameStateUI : MonoBehaviour
    {
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject gameoverPanel;
        [SerializeField] private GameObject readyPanel;

        [SerializeField] private TextMeshProUGUI enemyCountLabel;
        [SerializeField] private TextMeshProUGUI livesCount;
        private GameState gameState;

        void Start()
        {
            GameManager.Instance.OnGameOver.AddListener(OnGameOver);
            GameManager.Instance.OnGameWon.AddListener(OnGameWon);

            GameManager.Instance.OnLivesUpdated.AddListener(OnUpdateLife);
            GameManager.Instance.OnEnemyCountUpdated.AddListener(OnEnemyCountUpdate);
            GameManager.Instance.OnGameStart.AddListener(OnGameStart);

            gameState = GameManager.Instance.State;
            OnEnemyCountUpdate();
            OnUpdateLife();
        }

        #region EventListeners
        private void OnGameStart()
        {
            readyPanel.SetActive(false);
        }

        private void OnEnemyCountUpdate()
        {
            enemyCountLabel.text = string.Format("{0} / {1}", gameState.enemyCount, gameState.totalEnemies);
        }

        private void OnUpdateLife()
        {
            livesCount.text = "L: " + gameState.lives;
        }

        private void OnGameWon()
        {
            winPanel.SetActive(true);
            AudioManager.Instance.PlaySfx(AudioManager.CIdWin);
        }

        private void OnGameOver()
        {
            gameoverPanel.SetActive(true);
            AudioManager.Instance.PlaySfx(AudioManager.CIdGameOver);
        }
        #endregion

        public void LoadNextLevel()
        {
            AudioManager.Instance.PlaySfx(AudioManager.CIdClick);
            if(SceneManager.GetActiveScene().buildIndex+1 >= SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadMenu()
        {
            AudioManager.Instance.PlaySfx(AudioManager.CIdClick);
            SceneManager.LoadScene(0);
        }

        public void RetryLevel()
        {
            AudioManager.Instance.PlaySfx(AudioManager.CIdClick);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
