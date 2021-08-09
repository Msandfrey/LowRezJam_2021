using System.Collections;
using UnityEngine;
using IndieWizards.Enemy;

namespace IndieWizards.AI
{
    public class IdleAITree : AITreeBase
    {
        private bool isIdle = false;
        private EnemyController enemyController;
        private EnemyAnimationController enemyAnimationController;

        // Use this for initialization
        void Start()
        {
            enemyController = GetComponent<EnemyController>();
            enemyAnimationController = GetComponent<EnemyAnimationController>();
            if (enemyAnimationController) { Debug.Log("i got this animation thing down"); }
            isWaiting = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isWaiting && isIdle)
            {
                HaltTree();
                enemyController.ChangeStates(EnemyController.EnemyState.Patrol);
            }
        }

        protected override bool RunTree()
        {
            isWaiting = true;
            isIdle = true;
            StartCoroutine(Wait());
            //this function is called before the start function loads so it doesn't work the first time its called
            if (enemyAnimationController)
            {
                enemyAnimationController.Idle();
            }
            return true;
        }

        protected override bool HaltTree()
        {
            isIdle = false;
            return true;
        }
    }
}