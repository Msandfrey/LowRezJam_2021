using UnityEngine;
using IndieWizards.Character;

namespace IndieWizards.Consumables
{
    public class RedMushroomImpact : MonoBehaviour
    {
        [SerializeField]
        private GameObject redMushroom;
        [SerializeField]
        private int healValue;

        private Health health;
        private Animator animator;
        
        private void Start() 
        {
            health = FindObjectOfType<Health>();
            animator = redMushroom.GetComponent<Animator>();
        }

        public void HealCube()
        {
            health.RestoreHealth(healValue);
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
