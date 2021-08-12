using UnityEngine;

namespace IndieWizards.UI
{ 
    public class GameWonController : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameWonAnimationScreen;

        [SerializeField]
        private GameWonAnimationController gameWonAnimationController;

        [SerializeField]
        private GameObject gameWonPanel;

        // Start is called before the first frame update
        private void Start()
        {
            gameWonAnimationScreen.SetActive(false);
            gameWonPanel.SetActive(false);

            gameWonAnimationController.onAnimationComplete += HandleAnimationComplete;
        }

        public void GameWon()
        {
            gameWonAnimationScreen.SetActive(true);
            gameWonAnimationController.StartAnimation();
        }

        public void HandleAnimationComplete()
        {
            Invoke(nameof(ShowGameWonPanelText), 1.0f);
        }

        private void ShowGameWonPanelText()
        {
            gameWonPanel.SetActive(true);
            gameWonAnimationScreen.SetActive(false);
        }


    }
}
