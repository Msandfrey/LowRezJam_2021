using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Consumables
{
    public class GreenMushroomImpact : MonoBehaviour
    {
        [SerializeField] private GameObject greenMushroomAnimation;
        [SerializeField] public int poisonValue;
        [SerializeField] public int durationOfAffect;
        private PlayerHealth playerHealth;
        private Animator animator;
        private int cubeHealth;

        private void Start() {
            playerHealth = FindObjectOfType<PlayerHealth>();
            // animator = greenMushroomAnimation.GetComponent<Animator>();
        }

        public void GreenMushroom()
        {
            cubeHealth = playerHealth.GetCurrentHealth();
            cubeHealth -= poisonValue;
            playerHealth.GetUpdatedHealth(cubeHealth);
            Destroy(this.gameObject);
            StartCoroutine("AnimatePoison");
        }

        IEnumerator AnimatePoison()
        {
            greenMushroomAnimation.SetActive(true);
            yield return new WaitForSeconds(durationOfAffect);
            Debug.Log("Do you get this");
            greenMushroomAnimation.SetActive(false);
        }
    }
}
