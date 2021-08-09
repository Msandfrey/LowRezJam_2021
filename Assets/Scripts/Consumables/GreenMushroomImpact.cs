using UnityEngine;

namespace IndieWizards.Consumables
{
    public class GreenMushroomImpact : MonoBehaviour
    {
        [SerializeField]
        private GameObject greenMushroom;

        private Animator animator;

        private void Start() {
            animator = greenMushroom.GetComponent<Animator>();
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
