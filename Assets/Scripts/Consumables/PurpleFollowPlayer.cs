using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleFollowPlayer : MonoBehaviour
{
    private enum Direction {Up, Down, Left, Right, None}
    private Direction movementDirection;

    private void Awake()
    {
        movementDirection = Direction.None;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
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
        }
    }

    void FixedUpdate()
    {
        switch(movementDirection)
        {
            case Direction.Up:
                Rotate(Vector3.up);
                break;
            
            case Direction.Down:
                Rotate(Vector3.down);
                break;
            
            case Direction.Left:
                Rotate(Vector3.left);
                break;

            case Direction.Right:
                Rotate(Vector3.right);
                break;

            case Direction.None:
                break;

            default:
                Debug.LogError($"Unsupported movement direction => #{movementDirection}");
                break;
        }
    }

    private void Rotate(Vector3 direction)
    {
        if (direction.x != 0)
        {
            if (direction.x == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0f);
            }
            else if (direction.x == -1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -180f);
            }
        }
        
        if (direction.y != 0)
        {
            if (direction.y == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90f);
            }
            else if (direction.y == -1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90f);
            }
        }
    }
}
