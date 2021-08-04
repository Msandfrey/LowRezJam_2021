using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.AI;

namespace IndieWizards.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        //i made this but didn't use it at all
        public enum EnemyState { Idle, Patrol, Combat };
        public enum EnemyDirection { Up, Down, Left, Right, NotMoving };
        EnemyState currentState = EnemyState.Idle;
        EnemyDirection currentDirection = EnemyDirection.Left;
        //collision---not used now but maybe later? maybe just in the actual attack place
        //Rigidbody2D rigidbody;
        //animation
        EnemyAnimationController enemyAnimationController;
        //action script references
        CombatAITree combatAITree;
        IdleAITree idleAITree;
        EnemyTakeDamage enemyTakeDamage;
        PatrolAITree patrolAITree;
        Wait wait;
        //cone stuff
        [SerializeField] FieldOfViewCone fieldOfViewCone;
        [SerializeField] FieldOfViewCone playerDetectionCone;
        Vector2 aimDirection;

        // Start is called before the first frame update
        void Start()
        {
            //get all components
            //rigidbody = GetComponent<Rigidbody2D>();
            combatAITree = GetComponent<CombatAITree>();
            enemyAnimationController = GetComponent<EnemyAnimationController>();
            enemyTakeDamage = GetComponent<EnemyTakeDamage>();
            idleAITree = GetComponent<IdleAITree>();
            patrolAITree = GetComponent<PatrolAITree>();
            wait = GetComponent<Wait>();
            //set direction and state
            ChangeStates(currentState);
            ChangeDirection(currentDirection);
        }

        // Update is called once per frame
        void Update()
        {
            fieldOfViewCone.SetOrigin(transform.position);
            fieldOfViewCone.SetAimDirection(aimDirection);
            playerDetectionCone.SetOrigin(transform.position);
            playerDetectionCone.SetAimDirection(aimDirection);
        }

        void SwitchToIdle()
        {
            idleAITree.Run();
        }

        void SwitchToPatrol()
        {
            patrolAITree.Run();
        }

        void SwitchToCombat()
        {
            combatAITree.Run();
        }

        //deals with cone detection
        public void OnConeDetection()
        {
            if(currentState == EnemyState.Combat) { return; }
            patrolAITree.Halt();
            ChangeStates(EnemyState.Combat);
        }

        void OnConeLoseDetection()
        {
            patrolAITree.Halt();
            combatAITree.Halt();
            SwitchToIdle();
        }

        //deals with proximity detection
        void OnProximityDetection()
        {
            patrolAITree.Halt();
            SwitchToCombat();
        }

        void ChangeDirection(EnemyDirection enemyDirection)
        {
            switch (enemyDirection)//rotate 90 degrees counter-clockwise for some reason
            {
                case EnemyDirection.Up://up is left
                    aimDirection = Vector2.left;
                    break;
                case EnemyDirection.Down://down is right
                    aimDirection = Vector2.right;
                    break;
                case EnemyDirection.Left://left is down
                    aimDirection = Vector2.down;
                    break;
                case EnemyDirection.Right://right is up
                    aimDirection = Vector2.up;
                    break;
                default:
                    break;
            }
        }

        public void ChangeDirection(Vector2 direction)
        {
            //-------------QUESTION--------- is this func doing too much?
            float x = direction.x;
            float y = direction.y;
            //see if moving left or right
            bool right = x > 0;
            //see if moving up or down
            bool up = y > 0;
            //see if moving up/down faster than left/right
            bool verticalMovement = Mathf.Abs(y) > Mathf.Abs(x);

            if (verticalMovement)
            {
                //if moving up/down
                if (up)
                {
                    //if moving up
                    currentDirection = EnemyDirection.Up;
                    aimDirection = Vector2.left;
                }
                else
                {
                    currentDirection = EnemyDirection.Down;
                    aimDirection = Vector2.right;
                }
            }
            else
            {
                //if moving left/right
                if(x == 0)
                {
                    //not moving
                    currentDirection = EnemyDirection.NotMoving;
                }
                else if (right)
                {
                    //if moving right
                    currentDirection = EnemyDirection.Right;
                    aimDirection = Vector2.up;
                }
                else
                {
                    currentDirection = EnemyDirection.Left;
                    aimDirection = Vector2.down;
                }
            }
        }

        public void ChangeStates(EnemyState enemyState)
        {
            switch (enemyState)
            {
                case EnemyState.Combat:
                    SwitchToCombat();
                    break;
                case EnemyState.Idle:
                    SwitchToIdle();
                    break;
                case EnemyState.Patrol:
                    SwitchToPatrol();
                    break;
                default:
                    SwitchToIdle();
                    break;
            }
        }
    }
}
