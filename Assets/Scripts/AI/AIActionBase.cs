using UnityEngine;
using System.Collections;

namespace IndieWizards.AI
{
    public class AIActionBase : MonoBehaviour
    {
        protected bool isWaiting = false;
        [SerializeField]
        protected float waitTime = 1f;

        // Start is called before the first frame update
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

        protected bool Run()
        {
            return true;
        }

        protected bool Halt()
        {
            return true;
        }
    }
}
