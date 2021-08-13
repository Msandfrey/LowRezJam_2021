using UnityEngine;
using TMPro;
using IndieWizards.UI;

namespace IndieWizards.Character
{
    public class Health : MonoBehaviour
    {
        public delegate void DeathCallback();
        public DeathCallback onDeath;

        public delegate void DamageCallback();
        public DamageCallback onDamage;

        [Header("Hit point settings")]

        [SerializeField]
        private int initialHitPoints = 1;
        [SerializeField]
        private int maxHitPoints = 1;

        [Header("UI components")]
        [SerializeField] 
        private GameObject spriteMask;

        private bool isHeal;
        private int currentHitPoints;

        // Used to make sure we only trigger onDeath once
        private bool onDeathCallbackRaised;

        private void Awake()
        {
            currentHitPoints = initialHitPoints;
            onDeathCallbackRaised = false;
        }

        public void TakeDamage(int hitPoints)
        {
            currentHitPoints = Mathf.Max(currentHitPoints - hitPoints, 0);
            if (currentHitPoints > 0)
            {
                onDamage?.Invoke();
            }
            else if (currentHitPoints == 0 && !onDeathCallbackRaised)
            {
                onDeath?.Invoke();
                onDeathCallbackRaised = true;
            }

            float hp = HPIntervals();
            UpdateHealthBar(hp, isHeal=false);
        }

        public void RestoreHealth(int hitPoints)
        {
            currentHitPoints = Mathf.Min(currentHitPoints + hitPoints, maxHitPoints);
            float hp = HPIntervals();
            UpdateHealthBar(hp, isHeal=true);
        }

        private void UpdateHealthBar(float hitPoints, bool isHeal)
        {
            spriteMask.GetComponent<RectTransform>().anchoredPosition = new Vector3(currentHitPoints * hitPoints , 0, 0);
        }

        private float HPIntervals()
        {
            float maskSpriteWidth = spriteMask.GetComponent<RectTransform>().rect.width;
            float hp = (int)maskSpriteWidth / maxHitPoints;
            return hp;
        }
    }
}
