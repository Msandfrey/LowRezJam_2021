using System.Collections;
using UnityEngine;

namespace IndieWizards.AI
{
    public class AITreeBase : MonoBehaviour
    {
        protected bool isWaiting = false;
        [SerializeField]
        protected float waitTime = 2f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        protected IEnumerator Wait()
        {
            yield return new WaitForSeconds(waitTime);
            isWaiting = false;
        }
        public bool Run()
        {
            return RunTree();
        }
        public bool Halt()
        {
            return HaltTree();
        }
        protected virtual bool RunTree()
        {
            return true;
        }
        protected virtual bool HaltTree()
        {
            return true;
        }
    }
}