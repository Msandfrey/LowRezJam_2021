using UnityEngine;
using IndieWizards.Character;

namespace IndieWizards.Player 
{
    public class PlayerAttack : MonoBehaviour
    {
        [Header("Attack Settings")]
        [SerializeField]
        private int damagePerAttack = 1;
        [SerializeField]
        private float minTimeBetweenAttacks = 0.5f;

        private float timeSinceLastAttack = 0.0f;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                Attack(collision.gameObject);
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                Attack(collision.gameObject);
            }
        }

        private void Attack(GameObject gameObject)
        {
            if (timeSinceLastAttack - Time.deltaTime >= minTimeBetweenAttacks)
            {
                Health health = gameObject.GetComponent<Health>();
                if (health != null)
                {
                    Debug.Log("Attacking enemy");
                    health.TakeDamage(damagePerAttack);
                    timeSinceLastAttack = Time.deltaTime;
                }
            }
        }
    }
}
