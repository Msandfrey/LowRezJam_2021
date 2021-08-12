using System.Collections;
using UnityEngine;
using IndieWizards.Enemy;

namespace IndieWizards.AI
{
    public class CombatAITree : AITreeBase
    {
        private bool isInCombat = false;
        [SerializeField]
        private float combatMoveSpeed = 1f;
        [SerializeField]
        private float attackRange = 1f;

        enum CombatStates { Chasing, Attacking, Waiting };
        private CombatStates currentCombatState;

        private EnemyController enemyController;
        private EnemyAnimationController enemyAnimationController;
        private FindTarget findTarget;
        private MeleeAttackAIAction meleeAttackAIAction;
        private MoveToLocationAIAction moveToLocationAIAction;

        // Use this for initialization
        void Start()
        {
            findTarget = GetComponent<FindTarget>();
            meleeAttackAIAction = GetComponent<MeleeAttackAIAction>();
            moveToLocationAIAction = GetComponent<MoveToLocationAIAction>();
            enemyController = GetComponent<EnemyController>();
            enemyAnimationController = GetComponent<EnemyAnimationController>();
            combatMoveSpeed /= 100;
        }

        // Update is called once per frame
        void Update()
        {
            if (isInCombat && !isWaiting)
            {
                //1---------find target player
                Vector2 playerPosition = findTarget.Run(true);
                if(playerPosition == Vector2.zero) { return; }

                //2---------if in range, attack
                float distance = Vector2.Distance(playerPosition, transform.position);
                if(Mathf.Abs(distance) <= attackRange)
                {
                    AttackPlayer();
                }
                else if(Mathf.Abs(distance) > attackRange)
                {
                    //3---------move to player
                    //make sure damage collider is off
                    meleeAttackAIAction.EndAttackCollision();
                    ChasePlayer(playerPosition);
                }
            }
        }

        private void AttackPlayer()
        {
            meleeAttackAIAction.Run();
            StartCoroutine(Wait());
        }

        private void ChasePlayer(Vector2 playerPosition)
        {
            moveToLocationAIAction.Run(playerPosition, combatMoveSpeed);
            EnemyController.EnemyDirection direction = enemyController.GetCurrentDirection();
            switch (direction)
            {
                case EnemyController.EnemyDirection.Up:
                    enemyAnimationController.WalkUp();
                    break;
                case EnemyController.EnemyDirection.Down:
                    enemyAnimationController.WalkDown();
                    break;
                case EnemyController.EnemyDirection.Left:
                    enemyAnimationController.Walk();
                    GetComponent<SpriteRenderer>().flipX = false;
                    break;
                case EnemyController.EnemyDirection.Right:
                    enemyAnimationController.Walk();
                    GetComponent<SpriteRenderer>().flipX = true;
                    break;
            }
        }

        protected override bool RunTree()
        {
            isInCombat = true;
            return true;
        }

        protected override bool HaltTree()
        {
            isInCombat = false;
            meleeAttackAIAction.EndAttackCollision();
            return true;
        }
    }
}