using UnityEngine;
using IndieWizards.Audio;
using IndieWizards.Character;
using IndieWizards.Consumables;
using IndieWizards.GameManagement;
using IndieWizards.UI;

namespace IndieWizards.Player
{
    [RequireComponent(typeof(Consumer))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private AudioManager audioManager;

        private Health health;
        private GameManager gameManager;
        private Consumer consumer;
        private PlayerState playerState;

        private BoxCollider2D boxCollider;

        private void Awake()
        {
            consumer = GetComponent<Consumer>();
            consumer.onConsumeItem += HandleConsumeItem;

            health = GetComponent<Health>();
            health.onDeath += HandleDeath;

        }

        private void Start()
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();
        }

        public void UpdatePlayerState(PlayerState state)
        {
            playerState = state;

            switch (state)
            {
                case PlayerState.Attacking:
                    break;

                case PlayerState.Idle:
                    break;

                case PlayerState.Walking:
                    break;

                default:
                    Debug.LogError("Unsupported player state => " + state);
                    break;
            }
        }

        private void HandleConsumeItem(Consumable consumable)
        {
            switch(consumable.ConsummableType)
            {
                case ConsumableType.AcidMushroom:
                    ApplyAcidPowerUp(consumable.Amount);
                    audioManager.PlayCubeSlurp();
                    break;

                case ConsumableType.HealthMushroom:
                    ApplyHealthPowerUp(consumable.Amount);
                    audioManager.PlayCubeSlurp();
                    break;

                case ConsumableType.PoisonMushroom:
                    ApplyPoisonPowerUp(consumable.Amount);
                    audioManager.PlayCubeSlurp();
                    break;

                default:
                    Debug.LogError("Unsupported consumable => " + consumable.ConsummableType);
                    break;
            }

            GameObject.Destroy(consumable.gameObject);
        }

        private void ApplyAcidPowerUp(int damagePerAttack)
        {
            // disable enemy's meleeattack damagePerAttack on player to 0 when attacked?
            Debug.Log($"ate <color=purple>purple</color> mushroom");
        }

        private void ApplyPoisonPowerUp(int damagePerAttack)
        {
            // disable enemy's meleeattack damagePerAttack on player to 0 when attacked?
            Debug.Log($"ate <color=green>green</color> mushroom");   
        }

        private void ApplyHealthPowerUp(int hitpoints)
        {
            health.RestoreHealth(hitpoints);
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
