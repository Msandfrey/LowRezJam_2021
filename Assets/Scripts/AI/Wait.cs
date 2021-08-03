using System.Collections;
using UnityEngine;

namespace IndieWizards.AI
{
    public class Wait : MonoBehaviour
    {
        [SerializeField]
        float waitTime = 1f;
        public IEnumerator Run()
        {
            //maybe change
            yield return new WaitForSeconds(waitTime);
        }
    }
}