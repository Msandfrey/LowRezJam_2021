using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Enemy;

namespace IndieWizards.Player 
{
    public class PlayerAttack : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider) 
        {
            if (!collider.gameObject.GetComponent<TakeDamage>())
            {
                return;
            }
            
            Debug.Log("I'm about to eat you");
            TakeDamage takeDamage = collider.gameObject.GetComponent<TakeDamage>();
            // update player score. 
            takeDamage.DestroyEnemy();
        }
    }
}
