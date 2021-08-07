using UnityEngine;

namespace IndieWizards.Consumables
{
    public class Consumer : MonoBehaviour
    {
        public delegate void ConsumeItemCallback(Consumable consumable);
        public ConsumeItemCallback onConsumeItem;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Consumable consumable = collision.gameObject.GetComponent<Consumable>();
            if (consumable != null)
            {
                onConsumeItem?.Invoke(consumable);
            }
        }
    }
}
