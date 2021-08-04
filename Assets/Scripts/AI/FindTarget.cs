﻿using System.Collections;
using UnityEngine;

namespace IndieWizards.AI
{
    public class FindTarget : MonoBehaviour
    {
        [SerializeField]
        Transform[] targetCheckpoints;
        int currentTarget = 0;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public Vector2 Run()
        {
            //get the next targetCheckpoint
            if(currentTarget < targetCheckpoints.Length) { return targetCheckpoints[currentTarget].position; }
            return Vector2.zero;
        }
        public void IterateTargetCheckpoint()
        {
            currentTarget++;
        }
    }
}