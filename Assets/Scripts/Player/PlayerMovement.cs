using UnityEngine;

namespace IndieWizards.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Tooltip("The the movement speed of the player")]
        [SerializeField]
        private float speed = 5.0f;
    
        private Animator animator;
        private SpriteRenderer spriteRenderer;

        private void Awake() 
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

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
            if (!Input.anyKey)
            {
                animator.SetBool("isMoving", false);
            }
        }


        private void Move(Vector3 direction)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * speed);
            // animation
            if(direction.x == -1) 
            {
                spriteRenderer.flipX = true;
            } 
            else if (direction.x == 1)
            {
                spriteRenderer.flipX = false;
            }
            animator.SetBool("isMoving", true);

        }
    }
}
