using System;
using UnityEngine;
using IndieWizards.Animations;
using IndieWizards.Audio;
using IndieWizards.Character;
using IndieWizards.Consumables;
using IndieWizards.GameManagement;

namespace IndieWizards.Player
{
    [RequireComponent(typeof(Consumer))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(TakeDamageAnimation))]
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
        private RedMushroomAnimation redMushroom;
        private PurpleMushroomAnimation purpleMushroom;
        private GreenMushroomAnimation greenMushroom;
        private TakeDamageAnimation takeDamageAnimation;

        private void Awake()
        {
            consumer = GetComponent<Consumer>();
            consumer.onConsumeItem += HandleConsumeItem;

            health = GetComponent<Health>();
            health.onDeath += HandleDeath;
            health.onDamage += HandleDamage;

            takeDamageAnimation = GetComponent<TakeDamageAnimation>();

            redMushroom = GameObject.FindObjectOfType<RedMushroomAnimation>();
            greenMushroom = GameObject.FindObjectOfType<GreenMushroomAnimation>();
            purpleMushroom = GameObject.FindObjectOfType<PurpleMushroomAnimation>();
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
                    audioManager.PlayCubeSlurp();
                    ApplyAcidPowerUp(consumable.Amount);
                    break;

                case ConsumableType.HealthMushroom:
                    audioManager.PlayCubeSlurp();
                    ApplyHealthPowerUp(consumable.Amount);
                    break;

                case ConsumableType.PoisonMushroom:
                    audioManager.PlayCubeSlurp();
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
            purpleMushroom.AnimateAcid();
            Invoke(nameof(PlayAcidSprayLoop), 0.5f);
        }

        private void ApplyPoisonPowerUp(int damagePerAttack)
        {
            greenMushroom.AnimatePoison();
            Invoke(nameof(PlayPoisonSound), 0.5f);
        }

        private void ApplyHealthPowerUp(int hitpoints)
        {
            redMushroom.AnimateHeal();
            Invoke(nameof(PlayHealingSound), 0.4f);
            health.RestoreHealth(hitpoints);
        }

        private void HandleDamage()
        {
            takeDamageAnimation.StartTakeDamageAnimation();
        }

        private void HandleDeath()
        {
            animator.SetTrigger("death");
            audioManager.PlayCubeDeath();
            Invoke(nameof(GameLost), 2.0f);
        }

        private void PlayAcidSprayLoop()
        {
            audioManager.PlayAcidSprayLoop();
        }

        private void PlayPoisonSound()
        {
            audioManager.PlayPoisonSound(audioManager.poison);
        }

        private void PlayHealingSound()
        {
            audioManager.PlayHealingSound();
        }

        private void GameLost()
        {   
            gameManager.GameOver(false);
        }

    }
}
