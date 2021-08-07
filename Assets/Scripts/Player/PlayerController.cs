using UnityEngine;
using IndieWizards.Character;
using IndieWizards.GameManagement;

namespace IndieWizards.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        private Health health;
        private GameManager gameManager;

        private void Start()
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();

            health = GetComponent<Health>();
            health.onDeath += HandleDeath;
        }

        private void HandleDeath()
        {
            animator.SetTrigger("death");

            Invoke(nameof(GameLost), 5.0f);
        }

        private void GameLost()
        {
            gameManager.GameOver(false);
        }
    }
}
