using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Consumables
{
    public class RedMushroomImpact : MonoBehaviour
    {
        [SerializeField] private GameObject redMushroom;
        [SerializeField] public int healValue;
        private int cubeHealth;
        private PlayerHealth playerHealth;
        private Animator animator;
        
        private void Start() 
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            animator = redMushroom.GetComponent<Animator>();
        }

        public void HealCube()
        {
            cubeHealth = playerHealth.GetCurrentHealth();
            cubeHealth += healValue;
            playerHealth.GetUpdatedHealth(cubeHealth);
        }

        public void AnimateHeal()
        {
            animator.SetTrigger("heal");
        }

        public void DestroyRedMushroom()
        {
            Destroy(this.gameObject);
        }
    }
}
