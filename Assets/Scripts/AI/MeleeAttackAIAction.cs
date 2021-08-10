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
        [SerializeField]
        private float attackRange = 1f;

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
                    upCollider.size = new Vector2(leftCollider.size.x, attackRange);
                    break;
                case EnemyController.EnemyDirection.Down:
                    downCollider.enabled = true;
                    upCollider.size = new Vector2(leftCollider.size.x, attackRange);
                    break;
                case EnemyController.EnemyDirection.Left:
                    leftCollider.enabled = true;
                    leftCollider.size = new Vector2(attackRange, leftCollider.size.y);
                    break;
                case EnemyController.EnemyDirection.Right:
                    rightCollider.enabled = true;
                    leftCollider.size = new Vector2(attackRange, leftCollider.size.y);
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
            leftCollider.size = new Vector2(.1f, leftCollider.size.y);
            rightCollider.size = new Vector2(.1f, leftCollider.size.y);
            upCollider.size = new Vector2(leftCollider.size.x, .1f);
            downCollider.size = new Vector2(leftCollider.size.x, .1f);
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
            Debug.Log("entering");
            if (collision.gameObject.tag.Equals("Player") && isAttacking)
            {
                EndAttack();

                Attack(collision.gameObject.GetComponent<Health>());
            }
        }
    }
}