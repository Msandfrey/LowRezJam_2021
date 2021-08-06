using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Consumables
{
    public class TriggerRedMushroom : MonoBehaviour
    {
        [SerializeField] private GameObject redMushroom;

        private void OnTriggerEnter2D(Collider2D collider) 
        {
            if (!collider.gameObject.GetComponent<RedMushroomImpact>())
            {
                return; 
            }
            else 
            {
                RedMushroomImpact redMushroomImpact = collider.gameObject.GetComponent<RedMushroomImpact>();
                redMushroomImpact.HealCube();
                redMushroomImpact.DestroyRedMushroom();
                redMushroomImpact.AnimateHeal(); 
            }
        }
    }
}

