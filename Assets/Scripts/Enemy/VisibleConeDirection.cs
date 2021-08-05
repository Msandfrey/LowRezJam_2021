using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Enemy
{
    public class VisibleConeDirection : MonoBehaviour
    {
        public void FaceLeft()
        {
            Quaternion i = Quaternion.identity;
            i.eulerAngles = new Vector3(0, 0, 180);
            transform.rotation = i;
        }
        public void FaceRight()
        {
            Quaternion i = Quaternion.identity;
            i.eulerAngles = new Vector3(0, 0, 0);
            transform.rotation = i;
        }
        public void FaceUp()
        {
            Quaternion i = Quaternion.identity;
            i.eulerAngles = new Vector3(0, 0, 90);
            transform.rotation = i;
        }
        public void FaceDown()
        {
            Quaternion i = Quaternion.identity;
            i.eulerAngles = new Vector3(0, 0, -90);
            transform.rotation = i;
        }
    }
}
