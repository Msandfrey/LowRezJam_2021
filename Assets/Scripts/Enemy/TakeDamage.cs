using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Enemy 
{
    public class TakeDamage : MonoBehaviour
    {
        [SerializeField] public int enemyHealth;
        [SerializeField] public int poisonPotionDamage;
        [SerializeField] public int firePotionDamage;


        public void DestroyEnemy()
        {
            Destroy(this.gameObject);
        }

        public void PoisonEnemy()
        {
            // get poison value from Collectibles script.
            // manage enemyHealth from another script.
            // manage playerScore from another script.
            enemyHealth -= poisonPotionDamage;
            Debug.Log($"<color=green>Enemy poisoned. Enemy Health is now </color>" + enemyHealth);
        }

        public void BurnEnemy() 
        {
            enemyHealth -= firePotionDamage;
            Debug.Log($"<color=red>Enemy burned. Enemy Health is now </color>" + enemyHealth);
        }
    }
}
