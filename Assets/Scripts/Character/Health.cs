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
        private int initialHitPoints;
        [SerializeField]
        private int maxHitPoints;

        [Header("UI components")]
        private TextMeshProUGUI healthText;
        
        private int currentHitPoints;

        private void Awake()
        {
            currentHitPoints = initialHitPoints;
        }

        public void ApplyDamage(int hitPoints)
        {
            currentHitPoints = Mathf.Max(currentHitPoints - hitPoints, 0);

            if (currentHitPoints == 0)
            {
                Debug.Log("HP is at zero. Invoking onDeath callback");
                onDeath?.Invoke();
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
