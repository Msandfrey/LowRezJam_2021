using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Enemy;

namespace IndieWizards.Player 
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] public float distanceToKill;

        private void OnCollisionEnter2D(Collision2D collider) 
        {
            TakeDamage takeDamage = collider.gameObject.GetComponent<TakeDamage>();

            // if cube is X pixels away from enemy, and is facing it.
            float distance =  Vector3.Distance(transform.position, collider.gameObject.transform.position);
            if (distance <= distanceToKill)
            {
                takeDamage.DestroyEnemy();
            }
        } 
    }
}
