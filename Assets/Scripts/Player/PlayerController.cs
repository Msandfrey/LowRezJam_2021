using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Player
{
    public class PlayerController : MonoBehaviour
    {
        PlayerMovement playerMovement;
        PlayerAttack playerAttack;
        PlayerHealth playerHealth;

        void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerAttack = GetComponent<PlayerAttack>();
            playerHealth = GetComponent<PlayerHealth>();
        }

        void Update()
        {
            
        }
    }
}
