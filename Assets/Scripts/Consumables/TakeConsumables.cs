using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Consumables
{
    public class TakeConsumables : MonoBehaviour
    {
        [SerializeField] public int cubeHealth; // keep in separate script.

        [SerializeField] public int mushroomHealthAffect;
        [SerializeField] public int durationOfAffect;

        public void DestroyMushroom()
        {
            Destroy(this.gameObject);
        }

        public void RedMushroom()
        {
            cubeHealth += mushroomHealthAffect;
        }

        public void GreenMushroom()
        {
            // generate 1 space aura around cube for 5 seconds.
            cubeHealth -= mushroomHealthAffect;
        }

        public void PurpleMushroom()
        {
            // generate cone for 5 seconds so cube can attack enemies in sight.
            // enable game object with collider from cube to detect collider of mushroom
            
        }
    }
}
