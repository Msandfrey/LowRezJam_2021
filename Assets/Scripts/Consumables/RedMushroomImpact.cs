using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Consumables
{
    public class RedMushroomImpact : MonoBehaviour
    {
        private int cubeHealth;
        private Animator animator;
        private SpriteRenderer spriteRenderer;
        [SerializeField] private GameObject redMushroomAnimation;
        [SerializeField] public int mushroomHealthAffect;
        
        private void Start() 
        {
            // PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            animator = redMushroomAnimation.GetComponent<Animator>();
            spriteRenderer = redMushroomAnimation.GetComponent<SpriteRenderer>();
        }

        public void RedMushroom()
        {
            // get cube health value
            // cubeHealth = playerHealth.GetHealth();
            cubeHealth += mushroomHealthAffect;
            Debug.Log($"Cube Health is now: {cubeHealth}");
            Destroy(this.gameObject);
            // animator.Play("Heal");
            // animator.StopPlayback();
            // animator.SetTrigger("heal");
            // redMushroomAnimation.SetActive(false);
        }
    }
}
