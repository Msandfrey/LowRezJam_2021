using System.Collections;
using UnityEngine;
using IndieWizards.Enemy;

namespace IndieWizards.AI
{
    public class IdleAITree : AITreeBase
    {
        bool isIdle = false;
        EnemyController enemyController;

        // Use this for initialization
        void Start()
        {
            enemyController = GetComponent<EnemyController>();
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
            return true;
        }

        protected override bool HaltTree()
        {
            isIdle = false;
            return true;
        }
    }
}