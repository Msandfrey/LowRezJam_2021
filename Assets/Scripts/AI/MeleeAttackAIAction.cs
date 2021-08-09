using UnityEngine;
using IndieWizards.Enemy;
using IndieWizards.Character;
using IndieWizards.UI;

namespace IndieWizards.AI
{
    public class MeleeAttackAIAction : MonoBehaviour
    {
        [Header("Colliders for Detecting Attack")]
        [SerializeField]
        private BoxCollider2D rightCollider;
        [SerializeField]
        private BoxCollider2D leftCollider;
        [SerializeField]
        private BoxCollider2D downCollider;
        [SerializeField]
        private BoxCollider2D upCollider;

        [Header("Attack Settings")]
        [Tooltip("Number of hitpoint damage done each attack")]
        [SerializeField]
        private int damagePerAttack;
        [SerializeField]
        private float minTimeBetweenAttacks = 1.0f;

        private float timeSinceLastAttack;
        private bool isAttacking = false;

        private EnemyController enemyController;

        private void Awake()
        {
            timeSinceLastAttack = Time.time;            
        }

        private void Start()
        {
            enemyController = GetComponent<EnemyController>();
        }

        public bool Run()
        {
            isAttacking = true;
            //either shoot out a 1 unit ray in the direction facing
            switch (enemyController.GetCurrentDirection())
            {
                case EnemyController.EnemyDirection.Up:
                    upCollider.enabled = true;
                    break;
                case EnemyController.EnemyDirection.Down:
                    downCollider.enabled = true;
                    break;
                case EnemyController.EnemyDirection.Left:
                    leftCollider.enabled = true;
                    break;
                case EnemyController.EnemyDirection.Right:
                    rightCollider.enabled = true;
                    break;
                default:
                    break;
            }
            //or just turn a thing on and off
            return true;
        }

        public void EndAttack()
        {
            //turn off collider
            upCollider.enabled = false;
            downCollider.enabled = false;
            leftCollider.enabled = false;
            rightCollider.enabled = false;
            isAttacking = false;
        }

        private void Attack(Health health)
        {
            float elapsedTime = Time.time - timeSinceLastAttack;

            if (elapsedTime - Time.deltaTime >= minTimeBetweenAttacks)
            {
                health.TakeDamage(damagePerAttack);
                timeSinceLastAttack = Time.time;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player") && isAttacking)
            {
                //turn off collider
                upCollider.enabled = false;
                downCollider.enabled = false;
                leftCollider.enabled = false;
                rightCollider.enabled = false;

                Attack(collision.gameObject.GetComponent<Health>());
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player") && isAttacking)
            {
                //turn off collider
                upCollider.enabled = false;
                downCollider.enabled = false;
                leftCollider.enabled = false;
                rightCollider.enabled = false;

                Attack(collision.gameObject.GetComponent<Health>());
            }
        }
    }
}