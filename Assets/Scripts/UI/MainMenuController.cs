using UnityEngine;
using IndieWizards.Audio;
using IndieWizards.GameManagment;

namespace IndieWizards.UI
{
    public class MainMenuController : MonoBehaviour
    {
        public AudioManager audioManager;
        public GameManager gameManager;

        public GameObject mainMenuPanel;
        public GameObject settingsPanel;

        private void Start()
        {
            ValidateDependencies();

            audioManager.PlayMainMenuMusic();

            ShowMainMenuPanel();
        }

        public void Play()
        {
            gameManager.Play();
        }

        public void ShowMainMenuPanel()
        {
            mainMenuPanel.SetActive(true);
            settingsPanel.SetActive(false);
        }

        public void ShowSettingsPanel()
        {
            mainMenuPanel.SetActive(false);
            settingsPanel.SetActive(true);
        }

        private void ValidateDependencies()
        {
            if (audioManager == null)
            {
                Debug.LogError("AudioManager is required but not set");
            }
            if (gameManager == null)
            {
                Debug.LogError("GameManager is required but not set");
            }
        }
    }
}
