using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IndieWizards.Collectibles
{
    [System.Serializable]
    public class CollectiblesList
    {
        public CollectiblesType collectiblesType;
        public int value;


        public enum CollectiblesType
        {
            Poison,
            Acid,
            Antidote
        }


        public Sprite GetCollectiblesSprite() 
        {
            switch(collectiblesType)
            {
                default:
                case CollectiblesType.Poison:   return CollectiblesAssets.Instance.poisonSprite;
                case CollectiblesType.Acid:     return CollectiblesAssets.Instance.acidSprite;
                case CollectiblesType.Antidote: return CollectiblesAssets.Instance.antidoteSprite;
            }
        }
    }
}
