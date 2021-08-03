using UnityEngine;

namespace IndieWizards.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Tooltip("The the movement speed of the player")]
        [SerializeField]
        private float speed = 5.0f;

        void Update()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                Move(Vector3.up);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Move(Vector3.left);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                Move(Vector3.down);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Move(Vector3.right);
            }
        }

        private void Move(Vector3 direction)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * speed);
        }
    }
}
