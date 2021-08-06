using UnityEngine;
using IndieWizards.Audio;

namespace IndieWizards.GameManagment
{
    public class GameManager : MonoBehaviour
    {
        public SceneLoader sceneLoader;
        public AudioManager audioManager;

        public GameObject gameOverWonPanel;
        public GameObject gameOverLostPanel;

        private void Awake()
        {
            gameOverLostPanel.SetActive(false);
            gameOverWonPanel.SetActive(false);
            Time.timeScale = 1.0f;
        }

        private void Start()
        {
            audioManager.PlayGameMusic();    
        }

        public void Play()
        {
            sceneLoader.LoadGameScene();    
        }

        public void GameOver(bool won)
        {
            Pause();

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
        }

        public void Resume()
        {
            Time.timeScale = 1.0f;
        }
    }
}
