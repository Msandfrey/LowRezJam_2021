using UnityEngine;
using UnityEngine.SceneManagement;

namespace IndieWizards.GameManagment
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadGameScene()
        {
            SceneManager.LoadScene("Thomas");
        }

        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene("MainMenuScreen");
        }
    }
}
