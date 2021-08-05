using UnityEngine;
using System.Collections;
using IndieWizards.Enemy;

namespace IndieWizards.AI
{
    public class PatrolAITree : AITreeBase
    {
        bool isPatrolling = false;
        //bool isWaiting = false;
        [SerializeField]
        float moveSpeed = 1f;
        FindTarget findTarget;
        MoveToLocationAIAction moveToLocationAIAction;
        EnemyController enemyController;
        EnemyAnimationController enemyAnimationController;

        // Start is called before the first frame update
        void Start()
        {
            moveSpeed /= 100f;//make the speed small so its not too fast but the number we put in isnt super tiny
            findTarget = GetComponent<FindTarget>();
            moveToLocationAIAction = GetComponent<MoveToLocationAIAction>();
            enemyController = GetComponent<EnemyController>();
            enemyAnimationController = GetComponent<EnemyAnimationController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isPatrolling && !isWaiting)
            {
                //1-----find a target
                Vector2 targetLocation = findTarget.Run();
                if(targetLocation == Vector2.zero) { return; }

                //2------move to target
                bool isTargetLocationReached = moveToLocationAIAction.Run(targetLocation, moveSpeed);
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

                //3------if target reached iterate checkpoint and wait a sec
                if (isTargetLocationReached)
                {
                    findTarget.IterateTargetCheckpoint();
                    isWaiting = true;
                    enemyAnimationController.Idle();
                    StartCoroutine(Wait());
                }
            }
        }

        protected override bool RunTree()
        {
            isPatrolling = true;
            return true;
        }

        protected override bool HaltTree()
        {
            isPatrolling = false;
            return true;
        }

    }
}
