using UnityEngine;
using IndieWizards.AI;
using IndieWizards.Character;

namespace IndieWizards.Enemy
{
    [RequireComponent(typeof(Health))]
    public class EnemyController : MonoBehaviour
    {
        //i made this but didn't use it at all
        public enum EnemyState { Idle, Patrol, Combat };
        public enum EnemyDirection { Up, Down, Left, Right, NotMoving };

        //cone stuff
        [Header("Line of sight settings")]
        [SerializeField]
        private VisibleConeDirection visibleConeDirection;

        [SerializeField]
        private FieldOfViewCone fieldOfViewCone;
        
        [SerializeField]
        private FieldOfViewCone playerDetectionCone;

        private EnemyState currentState = EnemyState.Idle;
        private EnemyDirection currentDirection = EnemyDirection.Left;

        private EnemyAnimationController enemyAnimationController;

        private CombatAITree combatAITree;
        private IdleAITree idleAITree;
        private PatrolAITree patrolAITree;
        private Vector2 aimDirection;
        private Health health;

        private void Awake()
        {
            health = GetComponent<Health>();
            health.onDeath += HandleDeath;

            combatAITree = GetComponent<CombatAITree>();
            enemyAnimationController = GetComponent<EnemyAnimationController>();
            idleAITree = GetComponent<IdleAITree>();
            patrolAITree = GetComponent<PatrolAITree>();
        }

        private void HandleDeath()
        {
            Debug.Log("I've been killed");
            Destroy(this.gameObject);
        }

        private void Start()
        {
            //set direction and state
            ChangeStates(currentState);
            ChangeDirection(currentDirection);
        }

        private void Update()
        {
            fieldOfViewCone.SetOrigin(transform.position);
            fieldOfViewCone.SetAimDirection(aimDirection);
            playerDetectionCone.SetOrigin(transform.position);
            playerDetectionCone.SetAimDirection(aimDirection);
        }

        public EnemyState GetCurrentState()
        {
            return currentState;
        }

        public EnemyDirection GetCurrentDirection()
        {
            return currentDirection;
        }

        void SwitchToIdle()
        {
            enemyAnimationController.Idle();
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
            Debug.Log("is change dir getting called");
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
                    visibleConeDirection.FaceUp();
                }
                else
                {
                    currentDirection = EnemyDirection.Down;
                    aimDirection = Vector2.right;
                    visibleConeDirection.FaceDown();
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
                    visibleConeDirection.FaceRight();
                }
                else
                {
                    currentDirection = EnemyDirection.Left;
                    aimDirection = Vector2.down;
                    visibleConeDirection.FaceLeft();
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
