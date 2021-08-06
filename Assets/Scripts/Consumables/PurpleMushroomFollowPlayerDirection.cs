using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndieWizards.Player;

namespace IndieWizards.Consumables
{
    public class PurpleMushroomFollowPlayerDirection : MonoBehaviour
    {
        [SerializeField] private GameObject cube;


        private void Update() {
            FollowCube();
        }

        private void FollowCube()
        {            
            Debug.Log("purple's rotation: " + transform.rotation);
            Debug.Log(cube.transform.position.x);
        }
    }
}
