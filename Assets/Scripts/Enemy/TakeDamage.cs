using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Enemy 
{
    public class TakeDamage : MonoBehaviour
    {
        public void DestroyEnemy()
        {
            Destroy(this.gameObject);
        }
    }
}
