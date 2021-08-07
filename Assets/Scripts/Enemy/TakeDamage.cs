using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;
using IndieWizards.UI;

namespace IndieWizards.Enemy 
{
    public class TakeDamage : MonoBehaviour
    {
        [SerializeField] public int enemyDamageInHitPoints;
        public void DestroyEnemy()
        {
            
            Destroy(this.gameObject);
        }

        private void AttackEnemy(Health health, HealthBar healthBar)
        {
            health.ApplyDamage(enemyDamageInHitPoints);
            healthBar.DecreaseHealthBar(enemyDamageInHitPoints);
        }
    }
}
