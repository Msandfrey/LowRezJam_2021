using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Consumables
{
    public class PurpleMushroomImpact : MonoBehaviour
    {
        [SerializeField] private GameObject cube;

        private void FixedUpdate() 
        {
            
        }

        public void PurpleMushroom()
        {
            // generate cone for 5 seconds so cube can attack enemies in sight.
            // enable game object with collider from cube to detect collider of mushroom
            Debug.Log("purple got eaten. acid cone up.");
            Destroy(this.gameObject);
        }
    }
}

