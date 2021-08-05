using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Consumables
{
    public class TriggerRedMushroom : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider) 
        {
            if (!collider.gameObject.GetComponent<RedMushroomImpact>())
            {
                return; 
            }
            else 
            {
                RedMushroomImpact redMushroomImpact = collider.gameObject.GetComponent<RedMushroomImpact>();
                redMushroomImpact.RedMushroom();
                // animation of hearts. (put on player controller);
            }
        }
    }
}

