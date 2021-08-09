using System.Collections;
using UnityEngine;

namespace IndieWizards.Enemy
{
    public class FieldOfViewCone : MonoBehaviour
    {
        //-------notes-----------------
        //i think i found out just now that i need to change the position of this fuckin thing 
        //in order to have this as child that follows it. this makes it so each cone can just look
        //for enemycontroller in parent.... or i just drag and drop in. why brain think in circles...
        private Vector3 origin;
        private float angleIncrease;
        [SerializeField] private EnemyController enemyController;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float viewDistance;
        [SerializeField] private float startingAngle;
        [SerializeField] private float fov;
        [SerializeField] private int rayCount;

        // Use this for initialization
        void Start()
        {
            angleIncrease = fov / rayCount;
            origin = transform.position;
        }

        private void LateUpdate()
        {
            SearchForPlayer();
        }

        private void SearchForPlayer()
        {
            float angle = startingAngle;

            for(int i = 0; i <= rayCount; i++)
            {
                float angleRad = angle * (Mathf.PI / 180f);
                Vector3 direction = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
                
                RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, direction, viewDistance, layerMask);
                Debug.DrawRay(origin, direction * viewDistance, Color.blue, .2f);
                if(raycastHit2D)
                {
                    //enemy is in range and you can see
                    enemyController.OnPlayerSighted();
                    return;
                }
                angle -= angleIncrease;
            }
            //enemy is not in range and can't see
            enemyController.OnPlayerLostVision();
        }

        public void SetOrigin(Vector3 newOrigin)
        {
            origin = newOrigin;
        }

        public void SetAimDirection(Vector3 aimDirection)
        {
            aimDirection = aimDirection.normalized;
            float n = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            if(n<0) { n += 360; }
            startingAngle = Mathf.RoundToInt(n);
            startingAngle -= fov / 2f;
            startingAngle -= 90 - fov;
        }
    }
}