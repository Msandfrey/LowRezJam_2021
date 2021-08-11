using UnityEngine;
using System.Collections;
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
        private float delayForCollisionDetection;

        private float timeSinceLastAttackStart;
        private float timeSinceLastAttackDamage;

        private EnemyController enemyController;
        private EnemyAnimationController enemyAnimationController;

        private void Awake()
        {
            timeSinceLastAttackStart = Time.time;
            timeSinceLastAttackDamage = Time.time;            
        }

        private void Start()
        {
            enemyController = GetComponent<EnemyController>();
            enemyAnimationController = GetComponent<EnemyAnimationController>();
        }

        public bool Run(float attackRange)
        {
            float elapsedTime = Time.time - timeSinceLastAttackStart;

            if (elapsedTime - Time.deltaTime >= minTimeBetweenAttacks)
            {
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
                        rightCollider.enabled = false;
                        break;
                    case EnemyController.EnemyDirection.Right:
                        leftCollider.enabled = false;
                        rightCollider.enabled = true;
                        break;
                    default:
                        break;
                }
                enemyAnimationController.Attack();
                //StartCoroutine(BeginAttackCollision(attackRange));
                //StartCoroutine(EndAttackCollision());
                timeSinceLastAttackStart = Time.time;
            }
            return true;
        }

        private IEnumerator BeginAttackCollision(float attackRange)
        {
            yield return new WaitForSeconds(delayForCollisionDetection);
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
        }

        public void EndAttackCollision()
        {
            //turn off collider
            upCollider.enabled = false;
            downCollider.enabled = false;
            leftCollider.enabled = false;
            rightCollider.enabled = false;
        }

        private void AttackDealsDamage(Health health)
        {
            float elapsedTime = Time.time - timeSinceLastAttackStart;

            if (elapsedTime - Time.deltaTime >= minTimeBetweenAttacks)
            {
                //timeSinceLastAttackDamage = Time.time;
            }
                health.TakeDamage(damagePerAttack);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                Debug.Log("collide with player");
                EndAttackCollision();
                
                AttackDealsDamage(collision.gameObject.GetComponent<Health>());
            }
        }
    }
}