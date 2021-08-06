using UnityEngine;
using IndieWizards.Audio;
using IndieWizards.GameManagement;

namespace IndieWizards.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [Header("Requried Dependencies")]

        [SerializeField]
        private SceneLoader sceneLoader;
        [SerializeField]
        private AudioManager audioManager;


        [Header("UI Components")]

        [SerializeField]
        private GameObject mainMenuPanel;
        [SerializeField]
        private GameObject settingsPanel;

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
