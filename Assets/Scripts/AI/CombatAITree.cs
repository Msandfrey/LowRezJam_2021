using System.Collections;
using UnityEngine;
using IndieWizards.Enemy;

namespace IndieWizards.AI
{
    public class CombatAITree : AITreeBase
    {
        private bool isInCombat = false;
        [SerializeField]
        private float moveSpeed = 1f;
        [SerializeField]
        private float attackRange = 1.5f;

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
            moveSpeed /= 100;
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
                    bool doesAttackHit = false;
                    if (currentCombatState != CombatStates.Attacking)
                    {
                        enemyAnimationController.Attack();
                        doesAttackHit = meleeAttackAIAction.Run();
                        currentCombatState = CombatStates.Attacking;
                        //wait for animation length
                        StartCoroutine(Wait());
                        isWaiting = true;
                        return;
                    }
                    //wait for animation of attack to finish before stopping attack
                    //need check to jump straight into attack
                    meleeAttackAIAction.EndAttackCollision();
                    if (doesAttackHit)
                    {

                    }
                    //2.5---wait
                    currentCombatState = CombatStates.Waiting;
                    StartCoroutine(Wait());
                    isWaiting = true;
                    return;
                }

                //failsafe until logic gets better
                if (isWaiting) { return; }
                //3---------move to player
                //making sure not attacking here
                meleeAttackAIAction.EndAttackCollision();

                currentCombatState = CombatStates.Chasing;
                moveToLocationAIAction.Run(playerPosition, moveSpeed);
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
        }

        protected override bool RunTree()
        {
            isInCombat = true;
            return true;
        }

        protected override bool HaltTree()
        {
            isInCombat = false;
            return true;
        }
    }
}