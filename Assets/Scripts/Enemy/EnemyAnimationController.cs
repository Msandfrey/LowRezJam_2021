using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Enemy
{
    public class EnemyAnimationController : MonoBehaviour
    {
        private Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Die()
        {
            animator.SetTrigger("death");
        }

        public void Walk()
        {
            // if you moving left/right
            animator.SetBool("isMoving", true);
            //animator.SetBool("isMovingUp", false);
            //animator.SetBool("isMovingDown", false);
        }

        public void Idle()
        {
            if (animator)
            {
                animator.SetBool("isMoving", false);
                animator.SetBool("isMovingUp", false);
                animator.SetBool("isMovingDown", false);
            }
        }

        public void WalkUp()
        {
            //moving up
            animator.SetBool("isMoving", true);
            animator.SetBool("isMovingUp", true);
            animator.SetBool("isMovingDown", false);
        }

        public void WalkDown()
        {
            //moving up
            animator.SetBool("isMoving", true);
            animator.SetBool("isMovingDown", true);
            animator.SetBool("isMovingUp", false);
        }

        public void SetUp()
        {
            animator.SetBool("isMovingUp", true);
            animator.SetBool("isMovingDown", false);
        }

        public void SetDown()
        {
            animator.SetBool("isMovingDown", true);
            animator.SetBool("isMovingUp", false);
        }

        public void SetSideways()
        {
            animator.SetBool("isMovingDown", false);
            animator.SetBool("isMovingUp", false);
        }

        public void Attack()
        {
            //attack
            animator.SetTrigger("attack");
            animator.SetBool("isMoving", false);
            //animator.SetBool("isMovingUp", false);
            //animator.SetBool("isMovingDown", false);
        }
    }
}
