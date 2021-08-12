using UnityEngine;
using System.Collections;
using IndieWizards.Audio;
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

        private float timeSinceLastAttack;

        private EnemyController enemyController;
        private EnemyAnimationController enemyAnimationController;

        private AudioManager audioManager;

        private void Awake()
        {
            timeSinceLastAttack = Time.time;        
        }

        private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
            enemyAnimationController = GetComponent<EnemyAnimationController>();
            enemyController = GetComponent<EnemyController>();
        }

        public void SetTimeForOnDamageDelay()
        {   //set time since last attack to now so 
            //the dude waits to attack when he turns around
            timeSinceLastAttack = Time.time;
        }

        public bool Run()
        {
            float elapsedTime = Time.time - timeSinceLastAttack;

            if (elapsedTime - Time.deltaTime >= minTimeBetweenAttacks)
            {
                switch (enemyController.GetCurrentDirection())
                {//need to turn on collider for direction attacking
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
                audioManager.PlayEnemyAttackSound();
                timeSinceLastAttack = Time.time;
            }
            return true;
        }

        public void EndAttackCollision()
        {
            //turn off colliders so no more attack
            upCollider.enabled = false;
            downCollider.enabled = false;
            leftCollider.enabled = false;
            rightCollider.enabled = false;
        }

        private void AttackDealsDamage(Health health)
        {
            health.TakeDamage(damagePerAttack);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                EndAttackCollision();
                AttackDealsDamage(collision.gameObject.GetComponent<Health>());
            }
        }
    }
}