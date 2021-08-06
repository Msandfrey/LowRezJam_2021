using UnityEngine;
using UnityEngine.SceneManagement;

namespace IndieWizards.GameManagment
{
    public class SceneLoader : MonoBehaviour
    {
        private const string GameScene = "Game";
        private const string MainMenuScene = "MainMenuScreen";

        public void LoadGameScene()
        {
            SceneManager.LoadScene(GameScene);
        }

        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(MainMenuScene);
        }
    }
}
