using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;

namespace IndieWizards.Consumables
{
    public class PowerUpsAttack : MonoBehaviour
    {
        [Header("Power Ups' Attack Settings")]
        [SerializeField]
        private int damagePerAttack = 1;
        [SerializeField]
        private float minTimeBetweenAttacks = 0.5f;

        private float timeSinceLastAttack;

        private void Awake()
        {
            // init time since last attack to be past in order to
            // avoid potential bugs where the player finds an enemy at the very start of the game
            timeSinceLastAttack = Time.time - minTimeBetweenAttacks; 
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag.Equals("Enemy"))
            {
                Attack(collider.gameObject);
            }
        }

        private void OnTriggerStay2D(Collider2D collider)
        {
            if (collider.gameObject.tag.Equals("Enemy"))
            {
                Attack(collider.gameObject);
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
                    timeSinceLastAttack = Time.time;
                }
            }
        }
    }
}