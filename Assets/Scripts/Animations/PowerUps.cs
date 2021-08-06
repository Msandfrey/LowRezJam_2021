using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Animations
{
    public class PowerUps : MonoBehaviour
    {
        // Start is called before the first frame update
        public void ShowSpriteRenderer()
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        public void HideSpriteRenderer()
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

