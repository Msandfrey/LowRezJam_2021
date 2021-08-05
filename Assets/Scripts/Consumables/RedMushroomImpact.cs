using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Consumables
{
    public class RedMushroomImpact : MonoBehaviour
    {

        [SerializeField] private GameObject player;
        [SerializeField] private GameObject redMushroom;
        [SerializeField] public int healValue;
        private int cubeHealth;
        private bool isAnimating;
        private PlayerHealth playerHealth;
        private Animator animator;
        private SpriteRenderer spriteRenderer;
        
        private void Start() 
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            animator = redMushroom.GetComponent<Animator>();
            spriteRenderer = redMushroom.GetComponent<SpriteRenderer>();
        }

        private void Update() {
            if (isAnimating == true)
            {
                Debug.Log("I should see you");
                spriteRenderer.enabled = true;
            }
            else {
                Debug.Log("I shouldn't see you");
                spriteRenderer.enabled = false;
            }
        }

        public void RedMushroom()
        {
            // update cube health
            cubeHealth = playerHealth.GetCurrentHealth();
            cubeHealth += healValue;
            playerHealth.GetUpdatedHealth(cubeHealth);
        }

        public void AnimateHeal()
        {
            isAnimating = true;
            animator.SetTrigger("heal");
            // check when healing animation is done 
            // isAnimating = false;
            // Debug.Log("isAnimating is now false");
        }

        public void DestroyRedMushroom()
        {
            Destroy(this.gameObject);
        }
    }
}
