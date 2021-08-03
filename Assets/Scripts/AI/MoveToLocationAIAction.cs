using UnityEngine;

namespace IndieWizards.AI
{
    public class MoveToLocationAIAction : MonoBehaviour
    {
        //[SerializeField]
        //float speed = 1f;

        float resetSpeed;
        bool currentlyMoving = false;
        Vector2 targetLocation;

        private void Start()
        {
            //no mas
            //resetSpeed = speed;
        }
        private void Update()
        {
            //no mas
            /*if (currentlyMoving)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
            }*/
        }

        public bool Run(Vector2 newLocation, float speed)
        {
            transform.position = Vector2.MoveTowards(transform.position, newLocation, speed);
            //currentlyMoving = true;
            //if we want them to move faster when attacking the player
            //if (isChasingPlayer) { speed *= 2; }

            //check if reached target(need function for within certain range)
            return transform.position == new Vector3(newLocation.x, newLocation.y);
        }
        /*bool Stop()
        {
            currentlyMoving = false;
            //if we care changing speed
            //speed = resetSpeed;
            return true;
        }*/
    }
}