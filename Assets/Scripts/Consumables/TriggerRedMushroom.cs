using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Consumables
{
    public class TriggerRedMushroom : MonoBehaviour
    {
        [SerializeField] private GameObject redMushroom;
        private bool isAnimating;
        private SpriteRenderer spriteRenderer;


        private void Start() 
        {
            spriteRenderer = redMushroom.GetComponent<SpriteRenderer>();
        }


        private void Update() 
        {
            if (isAnimating == true)
            {
                Debug.Log("I should see you");
                spriteRenderer.enabled = true;
            }
            else if (isAnimating == false) 
            {
                Debug.Log("I shouldn't see you");
                spriteRenderer.enabled = false;
            }
        }
        private void OnTriggerEnter2D(Collider2D collider) 
        {
            if (!collider.gameObject.GetComponent<RedMushroomImpact>())
            {
                return; 
            }
            else 
            {
                RedMushroomImpact redMushroomImpact = collider.gameObject.GetComponent<RedMushroomImpact>();
                redMushroomImpact.RedMushroom();
                isAnimating = true;
                redMushroomImpact.AnimateHeal();
                // isAnimating = false; doesn't get set. 
                redMushroomImpact.DestroyRedMushroom();
                // animation of hearts. (put on player controller);
            }
        }
    }
}

