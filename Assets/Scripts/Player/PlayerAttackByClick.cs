using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Player 
{
    public class PlayerAttackByClick : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] public float distanceToGetKilled;

        private void Update() 
        {
            // if you're 5px away from enemy, and you are facing it.
            float distance =  Vector3.Distance(player.position, transform.position);
            if (distance <= distanceToGetKilled)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Debug.Log("CUBE JUST CLICKED & KILLED ME");
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
