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

        public void ShowCollider()
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        public void HideCollider()
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        public void ShowPolyCollider()
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }

        public void HidePolyCollider()
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}

