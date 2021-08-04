using System.Collections;
using UnityEngine;
using IndieWizards.Enemy;

namespace IndieWizards.AI
{
    public class CombatAITree : AITreeBase
    {
        bool isInCombat = false;
        [SerializeField]
        float moveSpeed = 1f;
        [SerializeField]
        float attackRange = 1.5f;

        FindTarget findTarget;
        MeleeAttackAIAction meleeAttackAIAction;
        MoveToLocationAIAction moveToLocationAIAction;

        // Use this for initialization
        void Start()
        {
            findTarget = GetComponent<FindTarget>();
            meleeAttackAIAction = GetComponent<MeleeAttackAIAction>();
            moveToLocationAIAction = GetComponent<MoveToLocationAIAction>();
            moveSpeed /= 100;
        }

        // Update is called once per frame
        void Update()
        {
            if (isInCombat && !isWaiting)
            {
                //1---------find target player
                Vector2 playerPosition = findTarget.Run(true);
                //2---------if in range attack
                float distance = Vector2.Distance(playerPosition, transform.position);
                if(Mathf.Abs(distance) <= attackRange)
                {
                    meleeAttackAIAction.Run();
                    //2.5---wait
                    StartCoroutine(Wait());
                    isWaiting = true;
                    return;
                }
                //3---------move to player
                moveToLocationAIAction.Run(playerPosition, moveSpeed);
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