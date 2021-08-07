using UnityEngine;
using IndieWizards.Enemy;
using IndieWizards.Character;
using IndieWizards.UI;

namespace IndieWizards.AI
{
    public class MeleeAttackAIAction : MonoBehaviour
    {
        [Header("Colliders for ...???")]
        [SerializeField]
        private BoxCollider2D rightCollider;
        [SerializeField]
        private BoxCollider2D leftCollider;
        [SerializeField]
        private BoxCollider2D downCollider;
        [SerializeField]
        private BoxCollider2D upCollider;

        [Header("Settings for ...???")]
        [SerializeField]
        private LayerMask layerMask;//set to player layer mask
        [SerializeField]
        private float viewDistance;

        [Header("Attack Settings")]
        [Tooltip("Number of hitpoint damage done each attack")]
        [SerializeField]
        private int damagePerAttack;
        [SerializeField]
        private float minTimeBetweenAttacks = 1.0f;

        private float timeSinceLastAttack = 0.0f;

        private EnemyController enemyController;

        // Start is called before the first frame update
        void Start()
        {
            enemyController = GetComponent<EnemyController>();
        }

        public bool Run()
        {
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
        }

        private void Attack(Health health, HealthBar healthBar)
        {
            if (timeSinceLastAttack - Time.deltaTime >= minTimeBetweenAttacks)
            {
                health.TakeDamage(damagePerAttack);
                healthBar.DecreaseHealthBar(damagePerAttack);
                timeSinceLastAttack = Time.deltaTime;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                //turn off collider
                upCollider.enabled = false;
                downCollider.enabled = false;
                leftCollider.enabled = false;
                rightCollider.enabled = false;

                Attack(collision.gameObject.GetComponent<Health>(),
                       collision.gameObject.GetComponent<HealthBar>());
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                Attack(collision.gameObject.GetComponent<Health>(),
                       collision.gameObject.GetComponent<HealthBar>());
            }
        }
    }
}