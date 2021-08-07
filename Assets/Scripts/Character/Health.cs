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
        private int initialHitPoints;
        [SerializeField]
        private int maxHitPoints;

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

        public void ApplyDamage(int hitPoints)
        {
            currentHitPoints = Mathf.Max(currentHitPoints - hitPoints, 0);

            if (currentHitPoints == 0 && !onDeathCallbackRaised)
            {
                Debug.Log("HP is at zero. Invoking onDeath callback");
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
            healthText.text = hitPoints.ToString();
        }
    }
}