using UnityEngine;
using IndieWizards.Audio;
using IndieWizards.GameManagment;

namespace IndieWizards.UI
{
    public class MainMenuController : MonoBehaviour
    {
        public AudioManager audioManager;
        public SceneLoader sceneLoader;

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
            sceneLoader.LoadGameScene();
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
            if (sceneLoader == null)
            {
                Debug.LogError("SceneLoader is required but not set");
            }
        }
    }
}
