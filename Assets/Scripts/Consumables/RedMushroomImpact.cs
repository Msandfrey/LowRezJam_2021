using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Consumables
{
    public class RedMushroomImpact : MonoBehaviour
    {

        
        private int cubeHealth;
        private PlayerHealth playerHealth;
        private Animator animator;
        private SpriteRenderer spriteRenderer;
        [SerializeField] private GameObject player;
        // [SerializeField] private GameObject redMushroom;
        [SerializeField] public int healValue;
        
        private void Start() 
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            // animator = player.GetComponent<Animator>();
            // spriteRenderer = player.GetComponent<SpriteRenderer>();
        }

        public void RedMushroom()
        {
            // get cube health value
            cubeHealth = playerHealth.GetCurrentHealth();
            cubeHealth += healValue;
            playerHealth.GetUpdatedHealth(cubeHealth);
            Destroy(this.gameObject);
            // redMushroom.SetActive(true);
            // animator.SetTrigger("heal");

            // redMushroom.SetActive(false);
        }
    }
}
