using UnityEngine;
using System.Collections;

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
        Wait wait;

        // Start is called before the first frame update
        void Start()
        {
            moveSpeed /= 100f;//make the speed small so its not too fast but the number we put in isnt super tiny
            findTarget = GetComponent<FindTarget>();
            moveToLocationAIAction = GetComponent<MoveToLocationAIAction>();
            wait = GetComponent<Wait>();
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

                //3------if target reached iterate checkpoint and wait a sec
                if (isTargetLocationReached)
                {
                    findTarget.IterateTargetCheckpoint();
                    isWaiting = true;
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
