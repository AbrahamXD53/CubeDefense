using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubeDefense
{
    /// <summary>
    /// Main menu script
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject levelSelect;
        [SerializeField] private GameObject playButton;

        private void Start()
        {
            AudioManager.Instance.PlayBackground(AudioManager.CIdBgMenu);
        }

        public void OpenLevelSelect()
        {
            levelSelect.SetActive(true);
            playButton.SetActive(false);

            AudioManager.Instance.PlaySfx(AudioManager.CIdClick);
        }

        public void LoadGameLevel(int level)
        {
            AudioManager.Instance.PlaySfx(AudioManager.CIdClick);
            SceneManager.LoadScene(level);
        }

    }

}