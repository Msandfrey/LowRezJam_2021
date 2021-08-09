using System.Collections.Generic;
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

        private HashSet<GameObject> enemies;

        private void Awake()
        {
            gameOverLostPanel.SetActive(false);
            gameOverWonPanel.SetActive(false);
            pauseMenu.SetActive(false);
            isPaused = false;

            enemies = new HashSet<GameObject>();
            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemies.Add(enemy);
            }

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
            else
            {
                foreach (GameObject enemy in enemies)
                {
                    if (enemy != null)
                    {
                        return;
                    }
                }

                // If we got this far, there are no more enemies left in the game
                // and we've won
                GameOver(true);
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
