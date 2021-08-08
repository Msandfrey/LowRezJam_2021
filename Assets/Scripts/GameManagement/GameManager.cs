using UnityEngine;
using IndieWizards.Audio;

namespace IndieWizards.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public SceneLoader sceneLoader;
        public AudioManager audioManager;

        public GameObject gameOverWonPanel;
        public GameObject gameOverLostPanel;
        public GameObject pauseMenu;

        private bool isPaused;

        private void Awake()
        {
            gameOverLostPanel.SetActive(false);
            gameOverWonPanel.SetActive(false);
            pauseMenu.SetActive(false);
            isPaused = false;

            Time.timeScale = 1.0f;
        }

        private void Start()
        {
            audioManager.PlayGameMusic();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Play()
        {
            sceneLoader.LoadGameScene();    
        }

        public void GameOver(bool won)
        {
            Time.timeScale = 0.0f;

            if (won)
            {
                gameOverWonPanel.SetActive(true);
            }
            else
            {
                gameOverLostPanel.SetActive(false);
            }
        }

        public void Pause()
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
            isPaused = true;
        }

        public void Resume()
        {
            Time.timeScale = 1.0f;
            isPaused = false;
            pauseMenu.SetActive(false);
        }
    }
}
