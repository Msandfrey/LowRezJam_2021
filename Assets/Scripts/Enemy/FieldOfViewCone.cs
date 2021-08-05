﻿using System.Collections;
using UnityEngine;

namespace IndieWizards.Enemy
{
    public class FieldOfViewCone : MonoBehaviour
    {
        //-------notes-----------------
        //i think i found out just now that i need to change the position of this fuckin thing 
        //in order to have this as child that follows it. this makes it so each cone can just look
        //for enemycontroller in parent.... or i just drag and drop in. why brain think in circles...
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private bool isLookingForPlayer = false;
        private Mesh mesh;
        private Vector3 origin;
        [SerializeField] private float startingAngle;
        [SerializeField] private float fov;
        [SerializeField] private int rayCount;
        private float angleIncrease;
        [SerializeField] private float viewDistance;
        [SerializeField] EnemyController enemyController;

        // Use this for initialization
        void Start()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            //fov = 90f;
            origin = transform.position;
            //get this from somewhere else

        }

        private void LateUpdate()
        {
         
            //rayCount = 2;
            angleIncrease = fov / rayCount;
            //viewDistance = 5f;
            float angle = startingAngle;

            Vector3[] vertices = new Vector3[rayCount + 2];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[rayCount*3];

            //origin = Vector2.zero;
            //Debug.Log(origin);
            
            vertices[0] = origin;

            int vertexIndex = 1;
            int triangleIndex = 0;
            for(int i = 0; i <= rayCount; i++)
            {
                float angleRad = angle * (Mathf.PI / 180f);
                Vector3 direction = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
                Vector3 vertex;
                RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, direction, viewDistance, layerMask);
                Debug.DrawRay(origin, direction * viewDistance, Color.blue, .2f);
                if(!raycastHit2D)
                {
                    //nohit
                    vertex = origin + direction * viewDistance;
                }
                else
                {
                    //vertex = origin + new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * viewDistance;
                    
                    vertex = raycastHit2D.point;
                    //if this is checked must only search the player layer
                    if (isLookingForPlayer)
                    {
                        enemyController.OnConeDetection();
                    }
                }
                vertices[vertexIndex] = vertex;

                if (i > 0)
                {
                    triangles[triangleIndex + 0] = 0;
                    triangles[triangleIndex + 1] = vertexIndex -1;
                    triangles[triangleIndex + 2] = vertexIndex;

                    triangleIndex += 3;
                }

                ++vertexIndex;
                angle -= angleIncrease;

            }


            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
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