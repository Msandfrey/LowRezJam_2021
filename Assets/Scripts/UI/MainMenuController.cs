using UnityEngine;
using IndieWizards.Audio;
using IndieWizards.GameManagment;

namespace IndieWizards.UI
{
    public class MainMenuController : MonoBehaviour
    {
        public AudioManager audioManager;
        public SceneLoader sceneLoader;

        private void Start()
        {
            ValidateDependencies();
            audioManager.PlayMainMenuMusic();
        }

        public void Play()
        {
            sceneLoader.LoadGameScene();
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
