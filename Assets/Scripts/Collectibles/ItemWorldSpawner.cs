using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Collectibles
{
    public class ItemWorldSpawner : MonoBehaviour
    {
        public CollectiblesList collectiblesList;

        private void Start()
        {
            GameObject spawnedItem = ItemWorld.SpawnItemWorld(transform.position, collectiblesList).gameObject;
            Destroy(gameObject);
        }

    }
}
