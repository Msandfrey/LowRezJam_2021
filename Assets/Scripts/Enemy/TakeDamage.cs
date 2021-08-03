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
            enemyHealth -= poisonPotionDamage;
            Debug.Log("Enemy health is now " + enemyHealth);
        }

        public void BurnEnemy() 
        {
            enemyHealth -= firePotionDamage;
            Debug.Log("Enemy health is now " + enemyHealth);
        }
    }
}
