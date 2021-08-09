using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Character;


// --- OBSOLETE NOW --- //
namespace IndieWizards.UI 
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private GameObject spriteMask;

        private Health health;
        public void DecreaseHealthBar(int hitPoints)
        {
            // get the type of impact: enemy, player, or red mushroom?

            // do this somewhere else
            int maxHitPoints = 2; // get the maxHitPoints from Health.cs, and make this as a paramter.
            int initialMaskSprite = 100; // get this somewhere else.
            float hp = (int)initialMaskSprite / maxHitPoints;

            float spriteMaskX = spriteMask.GetComponent<RectTransform>().anchoredPosition.x; 
            spriteMask.GetComponent<RectTransform>().anchoredPosition = new Vector3(spriteMaskX - hp, 0, 0);
        }
    }
}

