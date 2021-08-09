using UnityEngine;
using IndieWizards.Enemy;

namespace IndieWizards.AI
{
    public class MoveToLocationAIAction : MonoBehaviour
    {
        private EnemyController enemyController;

        private void Start()
        {
            enemyController = GetComponent<EnemyController>();
        }

        public bool Run(Vector2 newLocation, float speed)
        {
            //move towards position
            transform.position = Vector2.MoveTowards(transform.position, newLocation, speed);
            //update direction of movement
            Vector2 vec2Position = new Vector2(transform.position.x, transform.position.y);
            enemyController.ChangeDirection(newLocation - vec2Position);

            //check if reached target(need function for within certain range)
            return transform.position == new Vector3(newLocation.x, newLocation.y);
        }
    }
}