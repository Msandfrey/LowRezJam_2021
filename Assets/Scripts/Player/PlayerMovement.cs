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
            if (Input.GetKey(KeyCode.W))
            {
                Move(Vector3.up);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Move(Vector3.left);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Move(Vector3.down);
            }
            if (Input.GetKey(KeyCode.D))
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
