using UnityEngine;
using IndieWizards.Character;
using IndieWizards.Consumables;
using IndieWizards.GameManagement;
using IndieWizards.UI;
using System;

namespace IndieWizards.Player
{
    [RequireComponent(typeof(Consumer))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        private Health health;
        private HealthBar healthBar;
        private GameManager gameManager;
        private Consumer consumer;

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

        private void HandleConsumeItem(Consumable consumable)
        {
            switch(consumable.ConsummableType)
            {
                case ConsumableType.AcidMushroom:
                    ApplyAcidPowerUp(consumable.Amount);
                    break;

                case ConsumableType.HealthMushroom:
                    ApplyHealthPowerUp(consumable.Amount);
                    break;

                case ConsumableType.PoisonMushroom:
                    ApplyPoisonPowerUp(consumable.Amount);
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
            healthBar.RestoreHealthBar(hitpoints);
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
