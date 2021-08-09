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
        private HealthBar healthBar;
        private GameManager gameManager;
        private Consumer consumer;
        private PlayerState playerState;

        private void Awake()
        {
            consumer = GetComponent<Consumer>();
            consumer.onConsumeItem += HandleConsumeItem;

            health = GetComponent<Health>();
            health.onDeath += HandleDeath;

            healthBar = GetComponent<HealthBar>();
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
            Debug.Log("Not implemented");
        }

        private void ApplyPoisonPowerUp(int damagePerAttack)
        {
            Debug.Log("Not implemented");
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
