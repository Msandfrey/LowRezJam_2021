using System.Collections;
using UnityEngine;

namespace IndieWizards.AI
{
    public class CombatAITree : MonoBehaviour
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
            if (isInCombat)
            {
                //1---------find target player
                //2---------if in range attack
                    //2.5---wait
                //3---------move to player
            }
        }
        public bool RunTree()
        {
            isInCombat = true;
            return true;
        }
        public bool StopTree()
        {
            isInCombat = false;
            return true;
        }
    }
}