using System.Collections;
using UnityEngine;

namespace IndieWizards.AI
{
    public class CombatAITree : AITreeBase
    {
        bool isInCombat = false;
        [SerializeField]
        float moveSpeed = 1f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isInCombat && !isWaiting)
            {
                //1---------find target player
                //2---------if in range attack
                    //2.5---wait
                //3---------move to player
            }
        }
        protected override bool RunTree()
        {
            Debug.Log("got here bitch");
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