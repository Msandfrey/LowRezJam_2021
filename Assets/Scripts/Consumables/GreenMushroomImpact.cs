using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Consumables
{
    public class GreenMushroomImpact : MonoBehaviour
    {
        [SerializeField] private GameObject greenMushroomAnimation;
        [SerializeField] public int mushroomHealthAffect;
        [SerializeField] public int durationOfAffect;
        private PlayerHealth playerHealth;
        private Animator animator;
        private int cubeHealth;

        private void Start() {
            // playerHealth = GetComponent<PlayerHealth>();
            animator = greenMushroomAnimation.GetComponent<Animator>();
        }

        public void GreenMushroom()
        {
            // cubeHealth = playerHealth.GetHealth();
            // cubeHealth -= mushroomHealthAffect;
            // Debug.Log($"Cube health is now {cubeHealth}");
            Destroy(this.gameObject);
            // StartCoroutine("AnimatePoison");
        }

        IEnumerator AnimatePoison()
        {
            greenMushroomAnimation.SetActive(true);
            animator.Play("Poison");
            yield return new WaitForSeconds(durationOfAffect);
            Debug.Log("Finished coroutine at timestamp: " + Time.time);
            greenMushroomAnimation.SetActive(false);
        }
    }
}
