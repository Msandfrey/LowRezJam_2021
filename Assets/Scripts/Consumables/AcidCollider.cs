using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Enemy;

namespace IndieWizards.Consumables
{
    public class AcidCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider) 
        {
            if (!collider.gameObject.GetComponent<TakeDamage>())
            {
                return;
            }
            TakeDamage takeDamage = collider.gameObject.GetComponent<TakeDamage>();
            // update player score. 
            takeDamage.DestroyEnemy();
        }
    }
}

