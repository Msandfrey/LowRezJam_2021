using UnityEngine;
using TMPro;

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
        
        private int currentHitPoints;

        // Used to make sure we only trigger onDeath once
        private bool onDeathCallbackRaised;

        private void Awake()
        {
            currentHitPoints = initialHitPoints;
            onDeathCallbackRaised = false;
        }

        private void Start()
        {
            UpdateHealthText(currentHitPoints);
        }

        public void TakeDamage(int hitPoints)
        {
            currentHitPoints = Mathf.Max(currentHitPoints - hitPoints, 0);

            if (currentHitPoints == 0 && !onDeathCallbackRaised)
            {
                onDeath?.Invoke();
                onDeathCallbackRaised = true;
            }

            UpdateHealthText(currentHitPoints);
        }

        public void RestoreHealth(int hitPoints)
        {
            currentHitPoints = Mathf.Min(currentHitPoints + hitPoints, maxHitPoints);

            UpdateHealthText(currentHitPoints);
        }

        private void UpdateHealthText(int hitPoints)
        {
            if (healthText != null)
            {
                healthText.text = hitPoints.ToString();
            }
        }
    }
}
