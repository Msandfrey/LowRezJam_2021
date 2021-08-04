using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Consumables;

namespace IndieWizards.Player
{
    public class PlayerConsume : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider) 
        {
            TakeConsumables takeConsumables = collider.gameObject.GetComponent<TakeConsumables>();
            // check what kind of mushroom is it. 
            takeConsumables.DestroyMushroom(); 
        }
    }
}
