using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Consumables
{
    public class GreenMushroomImpact : MonoBehaviour
    {
        [SerializeField] private GameObject greenMushroom;
        [SerializeField] public int poisonValue;
        [SerializeField] public int durationOfAffect;
        private PlayerHealth playerHealth;
        private Animator animator;
        private int cubeHealth;

        private void Start() {
            playerHealth = FindObjectOfType<PlayerHealth>();
            animator = greenMushroom.GetComponent<Animator>();
        }

        public void PoisonCube()
        {
            cubeHealth = playerHealth.GetCurrentHealth();
            cubeHealth -= poisonValue;
            playerHealth.GetUpdatedHealth(cubeHealth);
        }

        public void AnimatePoison()
        {
            animator.SetTrigger("poison");
        }

        public void DestroyGreenMushroom()
        {
            Destroy(this.gameObject);
        }
    }
}
