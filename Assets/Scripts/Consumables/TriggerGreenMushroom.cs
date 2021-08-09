using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Consumables
{
    public class TriggerGreenMushroom : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider) 
        {
            if (!collider.gameObject.GetComponent<GreenMushroomImpact>())
            {
                return;
            }
            else 
            {
                GreenMushroomImpact greenMushroomImpact = collider.gameObject.GetComponent<GreenMushroomImpact>();
                greenMushroomImpact.DestroyGreenMushroom();
                greenMushroomImpact.AnimatePoison();
            }
        }
    }
}
