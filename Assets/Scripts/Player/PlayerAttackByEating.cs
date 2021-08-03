using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Player
{
    public class PlayerAttackByEating : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collider) 
        {
            if (collider.gameObject.name == "Enemy")
            {
                Debug.Log("I JUST ATE YA");
                Destroy(collider.gameObject);
            }
        }
    }
}
