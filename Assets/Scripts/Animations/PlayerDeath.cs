using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.GameManagement;

namespace IndieWizards.Animations
{
    public class PlayerDeath : MonoBehaviour
    {
        private GameManager gameManager;
        private bool won;

        private void Start() 
        {            
            gameManager = FindObjectOfType<GameManager>();    
        }

        public void GameOver()
        {
            gameManager.GameOver(!won);
        }
    }
}

