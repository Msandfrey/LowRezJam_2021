using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Consumables
{
    public class TriggerPurpleMushroom : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider) 
        {
            if (!collider.gameObject.GetComponent<PurpleMushroomImpact>())
            {
                return;
            }
            else 
            {
                PurpleMushroomImpact purpleMushroomImpact = collider.gameObject.GetComponent<PurpleMushroomImpact>();
                purpleMushroomImpact.PurpleMushroom();
                // start cone.   
            }
        }
    }
}
