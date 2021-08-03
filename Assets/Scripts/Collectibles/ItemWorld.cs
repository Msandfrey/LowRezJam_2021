using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Collectibles
{
    public class ItemWorld : MonoBehaviour
    {
        private CollectiblesList collectiblesList;
        private SpriteRenderer spriteRenderer;

        private void Awake() 
        {
            spriteRenderer = GetComponent<SpriteRenderer>();    
        }

        
        public static ItemWorld SpawnItemWorld(Vector3 position, CollectiblesList collectiblesList)
        {
            Transform transform = Instantiate(CollectiblesAssets.Instance.ItemWorld, position, Quaternion.identity);
            ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
            itemWorld.SetItem(collectiblesList);

            return itemWorld;
        }

        public void SetItem(CollectiblesList colliectiblesList)
        {
            this.collectiblesList = collectiblesList;
            spriteRenderer.sprite = collectiblesList.GetCollectiblesSprite();
        }

        public CollectiblesList GetCollectiblesList()
        {
            return collectiblesList;
        }

        public int GetValue()
        {
            return collectiblesList.value;
        }

        public void DestroyCollectible()
        {
            Destroy(gameObject);
        }
    }
}
