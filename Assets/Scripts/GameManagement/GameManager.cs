using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Audio;
using IndieWizards.Enemy;
using IndieWizards.UI;

namespace IndieWizards.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        [Header("Game Management")]
        [SerializeField]
        private SceneLoader sceneLoader;
        [SerializeField]
        private AudioManager audioManager;
        [SerializeField]
        private GameWonController gameWonController;

        [Header("UI Management")]
        [SerializeField]
        private GameObject gameOverLostPanel;
        [SerializeField]
        private GameObject pauseMenu;

        [Header("Debug Settings")]
        [SerializeField]
        private Transform debugBossFightSpawnPoint;

        private bool isPaused;

        private void Awake()
        {
            gameOverLostPanel.SetActive(false);
            pauseMenu.SetActive(false);
            isPaused = false;

            GameObject bossEnemy = GameObject.FindGameObjectWithTag("EnemyBoss");
            EnemyController enemyController = bossEnemy.GetComponent<EnemyController>();
            enemyController.onDeath += HandleBossDeath;

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
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                GameOver(true);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = debugBossFightSpawnPoint.position;
            }
        }

        public void Play()
        {
            audioManager.musicAudioSource.Stop();
            sceneLoader.LoadGameScene();    
        }

        public void Replay()
        {
            audioManager.musicAudioSource.Stop();
            sceneLoader.LoadGameScene();
        }

        public void GameOver(bool won)
        {
            if (won)
            {
                gameWonController.GameWon();
            }
            else
            {
                Time.timeScale = 0.0f;
                gameOverLostPanel.SetActive(true);
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

        private void HandleBossDeath()
        {
            Invoke(nameof(WonGame), 2.0f);
        }

        private void WonGame()
        {
            GameOver(true);
        }
    }
}
