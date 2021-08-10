using UnityEngine;

namespace IndieWizards.Animations
{
    public class TakeDamageAnimation : MonoBehaviour
    {
        [Tooltip("The color to apply to the sprite when taking damange")]
        [SerializeField]
        private Color spriteColorWhenDamaged = Color.red;

        private float damageEffectDuration = 0.1f;

        private SpriteRenderer spriteRenderer;
        private Color originalColor;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer == null)
            {
                Debug.LogError("SpriteRenderer not found. TakeDamangeAnimation will not be used.");
            }
        }

        public void StartTakeDamageAnimation()
        {
            if (spriteRenderer != null)
            {
                originalColor = spriteRenderer.color;
                spriteRenderer.color = spriteColorWhenDamaged;

                Invoke(nameof(StopTakeDamageAnimation), damageEffectDuration);
            }
        }

        private void StopTakeDamageAnimation()
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = originalColor;
            }
        }
    }
}
