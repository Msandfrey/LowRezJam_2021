using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Consumables
{
    public class PurpleMushroomAnimation : MonoBehaviour
    {
        private Animator animator;

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        public void AnimateAcid()
        {
            animator.SetTrigger("acid");
        }
    }
}

