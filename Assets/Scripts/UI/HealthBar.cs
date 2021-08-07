using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;

namespace IndieWizards.UI 
{
    public class HealthBar : MonoBehaviour
    {
        public void DecreaseHealthBar(int hitPoints)
        {
            float damagePercentage = (float)hitPoints / 100f;
            transform.position = new Vector3(transform.position.x - (damagePercentage), transform.position.y, transform.position.z);
        }

        public void RestoreHealthBar(int hitPoints)
        {
            float restorePercentage = (float)hitPoints / 100f;
            transform.position = new Vector3(transform.position.x + (restorePercentage), transform.position.y, transform.position.z);
        }
    }
}

