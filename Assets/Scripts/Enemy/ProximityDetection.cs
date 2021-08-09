using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Enemy
{
    public class ProximityDetection : MonoBehaviour
    {
        [SerializeField]
        private EnemyController enemyController;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.Equals("Player"))
            {
                enemyController.OnProximityDetection();
            }
        }
    }
}
