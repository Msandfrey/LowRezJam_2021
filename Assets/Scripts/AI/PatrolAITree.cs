using UnityEngine;

namespace IndieWizards.AI
{
    public class PatrolAITree : AIActionBase
    {
        bool isPatrolling = false;
        [SerializeField]
        float moveSpeed = 1f;
        FindTarget findTarget;
        MoveToLocationAIAction moveToLocationAIAction;
        Wait wait;
        // Start is called before the first frame update
        void Start()
        {
            findTarget = GetComponent<FindTarget>();
            moveToLocationAIAction = GetComponent<MoveToLocationAIAction>();
            wait = GetComponent<Wait>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isPatrolling)
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
                    //if we don't want to wait then we can remove this
                    wait.Run();
                }
            }
        }
        public bool RunTree()
        {
            isPatrolling = true;
            return true;
        }

        public bool StopTree()
        {
            isPatrolling = false;
            return true;
        }
    }
}
