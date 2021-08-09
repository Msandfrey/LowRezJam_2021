using UnityEngine;
using IndieWizards.AI;
using IndieWizards.Character;

namespace IndieWizards.Enemy
{
    [RequireComponent(typeof(Health))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Transform playerTransform;

        public enum EnemyState { Idle, Patrol, Combat };
        public enum EnemyDirection { Up, Down, Left, Right, NotMoving };

        private EnemyState currentState = EnemyState.Idle;
        private EnemyDirection currentDirection = EnemyDirection.Left;

        //cone stuff
        [Header("Line of sight settings")]
        [SerializeField]
        private VisibleConeDirection visibleConeDirection;

        [SerializeField]
        private FieldOfViewCone playerDetectionCone;

        private Vector2 aimDirection;

        private EnemyAnimationController enemyAnimationController;

        //ai tree stuff
        private CombatAITree combatAITree;
        private IdleAITree idleAITree;
        private PatrolAITree patrolAITree;
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

        private void Start()
        {
            //set direction and state
            ChangeStates(currentState);
            ChangeDirection(currentDirection);
        }

        private void Update()
        {
            playerDetectionCone.SetOrigin(transform.position);
            playerDetectionCone.SetAimDirection(aimDirection);
        }

        private void HandleDeath()
        {
            Debug.Log("I've been killed");
            Destroy(this.gameObject);
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
            currentState = EnemyState.Idle;
            enemyAnimationController.Idle();
            idleAITree.Run();
        }

        void SwitchToPatrol()
        {
            currentState = EnemyState.Patrol;
            patrolAITree.Run();
        }

        void SwitchToCombat()
        {
            currentState = EnemyState.Combat;
            combatAITree.Run();
        }

        //deals with cone detection
        public void OnPlayerSighted()
        {
            if(currentState == EnemyState.Combat) { return; }
            idleAITree.Halt();
            patrolAITree.Halt();
            ChangeStates(EnemyState.Combat);
        }

        public void OnPlayerLostVision()
        {
            if (currentState != EnemyState.Combat) { return; }
            patrolAITree.Halt();
            combatAITree.Halt();
            SwitchToIdle();
        }

        //deals with proximity detection
        public void OnProximityDetection()
        {
            if (currentState == EnemyState.Combat) { return; }
            idleAITree.Halt();
            patrolAITree.Halt();
            FacePlayer();
            //may be redundant if player calls this on sight
            SwitchToCombat();
        }

        private void OnDamage()
        {
            //jump to combat if not in combat
            if(currentState != EnemyState.Combat)
            {
                FacePlayer();
                //may be redundant if player calls this on sight
                SwitchToCombat();
            }
        }

        void FacePlayer()
        {
            //turn to face player
            //calculate angle
            //Vector2 angleToPlayer = GetAngleFromVector
            //changedirection
            ChangeDirection(transform.position - playerTransform.position);
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
