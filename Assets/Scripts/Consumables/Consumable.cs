using UnityEngine;

namespace IndieWizards.Consumables
{
    public class Consumable : MonoBehaviour
    {
        [SerializeField]
        private ConsumableType consumableType;

        [Tooltip("Amount of power (damage/hitpoints) the consumable provides")]
        [SerializeField]
        private int amount;

        /// <summary>
        /// The amount of power the consumable has. In the case of health, it will be hitpoints. In the case of
        /// attack bonus, it will be the amount of damage it does per attack.
        /// </summary>
        public int Amount { get { return amount; } }

        public ConsumableType ConsummableType { get { return consumableType; } set { consumableType = value; } }
    }
}