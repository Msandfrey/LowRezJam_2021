using UnityEngine;

namespace IndieWizards.Consumables
{
    public class Consumable : MonoBehaviour
    {
        [SerializeField]
        private ConsumableType consumableType;

        public ConsumableType ConsummableType { get { return consumableType; } set { consumableType = value; } }
    }
}