using UnityEngine;
using TMPro;
using IndieWizards.UI;

namespace IndieWizards.Character
{
    public class Health : MonoBehaviour
    {
        public delegate void DeathCallback();
        public DeathCallback onDeath;

        [Header("Hit point settings")]

        [SerializeField]
        private int initialHitPoints = 1;
        [SerializeField]
        private int maxHitPoints = 1;

        [Header("UI components")]
        [SerializeField]
        private TextMeshProUGUI healthText;
        [SerializeField] 
        private GameObject spriteMask;

        private bool isHeal;
        private int currentHitPoints;
        private int updatedCurrentHitPoints;

        // Used to make sure we only trigger onDeath once
        private bool onDeathCallbackRaised;

        private void Awake()
        {
            currentHitPoints = initialHitPoints;
            onDeathCallbackRaised = false;
        }

        private void Start()
        {
            // UpdateHealthText(currentHitPoints);
        }

        public void TakeDamage(int hitPoints)
        {
            currentHitPoints = Mathf.Max(currentHitPoints - hitPoints, 0);

            if (currentHitPoints == 0 && !onDeathCallbackRaised)
            {
                onDeath?.Invoke();
                onDeathCallbackRaised = true;
            }

            // UpdateHealthText(currentHitPoints);
            float hp = HPIntervals();
            UpdateHealthBar(hp, isHeal=false);
        }

        public void RestoreHealth(int hitPoints)
        {
            int updatedCurrentHitPoints = Mathf.Min(currentHitPoints, maxHitPoints);             
            Debug.Log("This should be a 9: " + currentHitPoints);
            Debug.Log("The updatedCurrentHitPoints should be a 9: " + updatedCurrentHitPoints);
            if (updatedCurrentHitPoints == maxHitPoints)
            {
                Debug.Log("HP Full");
            }
            else
            {
                float hp = HPIntervals();
                UpdateHealthBar(hp, isHeal=true);
                // UpdateHealthText(updatedCurrentHitPoints + hitPoints);
            }
        }

        // private void UpdateHealthText(int hitPoints)
        // {
        //     if (healthText != null)
        //     {
        //         healthText.text = hitPoints.ToString();
        //     }
        // }

        private void UpdateHealthBar(float hitPoints, bool isHeal)
        {

            float spriteMaskX = spriteMask.GetComponent<RectTransform>().anchoredPosition.x; // used for take damage only. why?
            spriteMask.GetComponent<RectTransform>().anchoredPosition = new Vector3(isHeal? currentHitPoints * hitPoints + hitPoints : spriteMaskX - hitPoints, 0, 0);
        }

        private float HPIntervals()
        {
            float maskSpriteWidth = spriteMask.GetComponent<RectTransform>().rect.width;
            float hp = (int)maskSpriteWidth / maxHitPoints;
            return hp;
        }
    }
}
