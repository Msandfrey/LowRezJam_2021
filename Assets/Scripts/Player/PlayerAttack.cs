using UnityEngine;
using IndieWizards.Audio;
using IndieWizards.Character;
using IndieWizards.UI;

namespace IndieWizards.Player 
{
    public class PlayerAttack : MonoBehaviour
    {
        [Header("Attack Settings")]
        [SerializeField]
        private int damagePerAttack = 1;
        [SerializeField]
        private float minTimeBetweenAttacks = 0.5f;

        private float timeSinceLastAttack;
        private AudioManager audioManager;

        private void Start() {
            audioManager = FindObjectOfType<AudioManager>();
        }

        private void Awake()
        {
            // init time since last attack to be past in order to
            // avoid potential bugs where the player finds an enemy at the very start of the game
            timeSinceLastAttack = Time.time - minTimeBetweenAttacks; 
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Contains("Enemy"))
            {
                Attack(collision.gameObject);
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Contains("Enemy"))
            {
                Attack(collision.gameObject);
            }
        }

        private void Attack(GameObject gameObject)
        {
            float elapsedTime = Time.time - timeSinceLastAttack;

            if (elapsedTime >= minTimeBetweenAttacks)
            {
                Health health = gameObject.GetComponent<Health>();

                if (health != null)
                {
                    Debug.Log("Attacking enemy");
                    health.TakeDamage(damagePerAttack);
                    audioManager.PlayCubeAttack();
                    timeSinceLastAttack = Time.time;
                }
            }
        }
    }
}
