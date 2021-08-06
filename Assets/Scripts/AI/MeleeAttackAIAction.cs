using UnityEngine;
using IndieWizards.Enemy;
using IndieWizards.Player;

namespace IndieWizards.AI
{
    public class MeleeAttackAIAction : MonoBehaviour
    {
        [SerializeField] BoxCollider2D rightCollider;
        [SerializeField] BoxCollider2D leftCollider;
        [SerializeField] BoxCollider2D downCollider;
        [SerializeField] BoxCollider2D upCollider;
        [SerializeField]
        LayerMask layerMask;//set to player layer mask
        [SerializeField]
        float viewDistance;
        Vector2 origin;
        EnemyController enemyController;

        // Start is called before the first frame update
        void Start()
        {
            enemyController = GetComponent<EnemyController>();
        }

        // Update is called once per frame
        void Update()
        {

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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.Equals("Player"))
            {
                //lower health
                //turn off collider
                upCollider.enabled = false;
                downCollider.enabled = false;
                leftCollider.enabled = false;
                rightCollider.enabled = false;
            }
        }
    }
}