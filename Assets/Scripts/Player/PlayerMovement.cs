using UnityEngine;

namespace IndieWizards.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private enum Direction { Up, Down, Left, Right, None }
        private Direction movementDirection;

        [Tooltip("The movement speed of the player")]
        [SerializeField]
        private float speed = 5.0f;
    
        private Animator animator;
        private SpriteRenderer spriteRenderer;

        private void Awake() 
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        
            movementDirection = Direction.None;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                movementDirection = Direction.Up;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                movementDirection = Direction.Left;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                movementDirection = Direction.Down;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                movementDirection = Direction.Right;
            }
            else
            {
                movementDirection = Direction.None;
                animator.SetBool("isMoving", false);
                animator.SetBool("isMovingUp", false);
                animator.SetBool("isMovingDown", false);

            }
        }

        void FixedUpdate()
        {
            switch(movementDirection)
            {
                case Direction.Up:
                    Move(Vector3.up);
                    break;

                case Direction.Down:
                    Move(Vector3.down);
                    break;

                case Direction.Left:
                    Move(Vector3.left);
                    break;

                case Direction.Right:
                    Move(Vector3.right);
                    break;

                case Direction.None:
                    break;

                default:
                    Debug.LogError($"Unsupported movement direction => #{movementDirection}");
                    break;
            }
        }


        private void Move(Vector3 direction)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * speed);
            // animation
            Debug.Log(direction.x + direction.y);
            if (direction.x != 0)
            {
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

            if (direction.y != 0)
            {
                if(direction.y == -1)
                {
                    animator.SetBool("isMovingDown", true);
                }
                else if (direction.y == 1)
                {
                    animator.SetBool("isMovingUp", true);
                }
            }
        }
    }
}
