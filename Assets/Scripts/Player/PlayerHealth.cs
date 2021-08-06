using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace IndieWizards.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [Header("Placeholder UI")]
        [SerializeField] public TextMeshProUGUI cubeHealthValue;
        [SerializeField] public int playerHealth;

        [SerializeField] private GameObject player;
        private Animator animator;

        private void Start() 
        {
            animator = player.GetComponent<Animator>();
        }

        private void Update() 
        {
            ShowHP();
            if (playerHealth <= 0)
            {
                playerHealth = 0;
                AnimateDeath();
            }
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

        private void AnimateDeath()
        {
            animator.SetTrigger("death");
        }

        public void ShowHP()
        {
            cubeHealthValue.text = playerHealth.ToString();
        }
    }
}
