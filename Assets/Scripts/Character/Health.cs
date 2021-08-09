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

            onDamage?.Invoke();

            UpdateHealthText(currentHitPoints);
            float hp = HPIntervals();
            UpdateHealthBar(hp, isHeal=false);
        }

        public void RestoreHealth(int hitPoints)
        {
            int updatedCurrentHitPoints = Mathf.Min((currentHitPoints + hitPoints), maxHitPoints); 
            if (updatedCurrentHitPoints == maxHitPoints)
            {
                Debug.Log("HP Full");
            }
            else
            {
                float hp = HPIntervals();
                UpdateHealthBar(hp, isHeal=true);
                UpdateHealthText(updatedCurrentHitPoints);
            }
        }

        private void UpdateHealthText(int hitPoints)
        {
            if (healthText != null)
            {
                healthText.text = hitPoints.ToString();
            }
        }

        // REMEMBER TO DELETE // 
        // Katie needs to organize her thoughts, remind herself why she does things: 
        /* 
            Q1.) What's my source of truth w.r.t updating health?
            A1.) This Health.cs' is my of truth for bookkeeping player and enemy health text + HP bar.
            I rely on var currentHitPoints, UpdateHealthText(), and UpdateHealthBar() to do it all.

            Q2.) Is this duplicate code? 
            A2.) No. This is the only method that tracks the damage/restoration of HP.

            Q3.) Are there variables here that I referenced from another script? 
            A3.) Nope. 

            Q4.) Do I reference any of these methods in other scripts? 
            A4.) Nope. Except for the public ones (e.g. RestoreHealth(), TakeDamage())

            Q5.) Should this method be written here?
            A5.) It can live here, but they will be called on RestoreHealth() AND/OR TakeDamage(), 
            and RestoreHealth() will be called in PlayerController.cs,
            TakeDamage() called in PlayerAttack.cs and MeleeAttackAIAction.cs.
        */
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
