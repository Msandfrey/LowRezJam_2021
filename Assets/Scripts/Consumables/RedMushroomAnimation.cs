using UnityEngine;

namespace IndieWizards.Consumables
{
    public class RedMushroomAnimation : MonoBehaviour
    {
        private Animator animator;

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        public void AnimateHeal()
        {
            animator.SetTrigger("heal");
        }


        // ideally, want to make a mushroom animation controller, but they all get triggered on wrong spots. 
        // public void AnimatePoison()
        // {
        //     animator.SetTrigger("poison");
        // }

        // public void AnimateAcid()
        // {
        //     animator.SetTrigger("acid");
        // }
    }
}
