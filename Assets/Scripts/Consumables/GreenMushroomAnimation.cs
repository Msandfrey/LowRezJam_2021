using UnityEngine;
using IndieWizards.Character;

namespace IndieWizards.Consumables
{
    public class GreenMushroomAnimation : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void AnimatePoison()
        {
            animator.SetTrigger("poison");
        }
    }
}
