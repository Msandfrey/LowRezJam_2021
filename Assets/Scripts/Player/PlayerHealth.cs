using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Consumables;

namespace IndieWizards.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] public int playerHealth;

        public int GetHealth()
        {
            return playerHealth;
        }

        private void Death()
        {
            if (playerHealth <= 0)
            {
               playerHealth = 0;
               // game over UI  
            }
        }
    }
}
