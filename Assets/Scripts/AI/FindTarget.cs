﻿using System.Collections;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.AI
{
    public class FindTarget : MonoBehaviour
    {
        [SerializeField]
        private Transform[] targetCheckpoints;
        private int currentTarget = 0;
        [SerializeField]
        private bool isLoopingPath = false;
        //dont rely on this. get from level/game manager
        private Transform playerTransform;

        private void Start()
        {
            playerTransform = FindObjectOfType<PlayerController>().transform;
        }

        public Vector2 Run(bool isLookingForPlayer = false)
        {
            if (isLookingForPlayer) { return playerTransform.position; }
            //get the next targetCheckpoint
            //if(targetCheckpoints.Length == 1) { return Vector2.zero; }
            if(currentTarget < targetCheckpoints.Length && targetCheckpoints[currentTarget] != null) { return targetCheckpoints[currentTarget].position; }
            return Vector2.zero;
        }

        public void IterateTargetCheckpoint()
        {
            currentTarget++;
            if (isLoopingPath)
            {
                if(currentTarget == targetCheckpoints.Length)
                {
                    currentTarget = 0;
                }
            }
        }
    }
}