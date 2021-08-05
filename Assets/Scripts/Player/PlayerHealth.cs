using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Consumables;
using TMPro;

namespace IndieWizards.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] public int playerHealth;

        [Header("Placeholder UI")]
        [SerializeField] public TextMeshProUGUI playerHealthValue;

        private void Update() {
            ShowHP();
        }

        
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

        public void ShowHP()
        {
            playerHealthValue.text = playerHealth.ToString();
        }
    }
}
