using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Enemy;

namespace IndieWizards.Player 
{
    public class PlayerAttackByClick : MonoBehaviour
    {
        [SerializeField] public float distanceToKill;

        private void Update() 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if(hit.collider != null)
                {
                    if (hit.collider.gameObject.name == "Enemy")
                    {
                        IndieWizards.Enemy.TakeDamage takeDamage = hit.collider.gameObject.GetComponent<TakeDamage>();

                        // if cube is X pixels away from enemy, and is facing it.
                        float distance =  Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);
                        if (distance <= distanceToKill)
                        {
                            Debug.Log("enemy gon get it");                        
                            takeDamage.PoisonEnemy();
                            // takeDamage.DestroyEnemy();
                        }
                    }
                }
            }
        }
    }
}
