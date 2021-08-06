using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Consumables
{
    public class PurpleMushroomImpact : MonoBehaviour
    {
        [SerializeField] private GameObject purpleMushroom;
        private Animator animator;

        private void Start() {
            animator = purpleMushroom.GetComponent<Animator>();
        }

        public void AnimateAcid()
        {
            animator.SetTrigger("acid");
        }

        public void DestroyPurpleMushroom()
        {
            Destroy(this.gameObject);
        }
    }
}

