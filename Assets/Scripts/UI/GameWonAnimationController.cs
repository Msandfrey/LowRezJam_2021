using UnityEngine;

namespace IndieWizards.UI
{
    public class GameWonAnimationController : MonoBehaviour
    {
        public delegate void AnimationCompleteCallback();
        public AnimationCompleteCallback onAnimationComplete;

        [SerializeField]
        private Animator animator;

        private void Start()
        {
            animator.StopPlayback();
        }

        public void AnimationComplete()
        {
            onAnimationComplete?.Invoke();
        }

        public void StartAnimation()
        {
            animator.StartPlayback();
        }
    }
}
