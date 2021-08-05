using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Consumables;

namespace IndieWizards.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] public int playerHealth;

        public int GetCurrentHealth()
        {
            return playerHealth;
        }

        public void GetUpdatedHealth(int updatedHealth)
        {
            playerHealth = updatedHealth;
            Debug.Log($"Cube health is now {playerHealth}");
        }
        

        private void Death()
        {
            if (playerHealth <= 0)
            {
               playerHealth = 0;
               // game over UI panel
            }
        }
    }
}
