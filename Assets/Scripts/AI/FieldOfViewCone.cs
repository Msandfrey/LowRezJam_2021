using System.Collections;
using UnityEngine;

namespace IndieWizards.AI
{
    public class FieldOfViewCone : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        Mesh mesh;
        Vector3 origin;
        float startingAngle;
        float fov;
        int rayCount;
        float angleIncrease;
        float viewDistance;
        // Use this for initialization
        void Start()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            fov = 90f;
            origin = Vector2.zero;
        }
        private void LateUpdate()
        {
         
            rayCount = 50;
            angleIncrease = fov / rayCount;
            viewDistance = 5f;
            float angle = startingAngle;

            Vector3[] vertices = new Vector3[rayCount + 2];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[rayCount*3];

            vertices[0] = origin;

            int vertexIndex = 1;
            int triangleIndex = 0;
            for(int i = 0; i <= rayCount; i++)
            {
                float angleRad = angle * (Mathf.PI / 180f);
                Vector3 vertex;
                RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)), viewDistance, layerMask);
                if(!raycastHit2D)
                {
                    //nohit
                    vertex = origin + new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * viewDistance;
                }
                else
                {
                    //vertex = origin + new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * viewDistance;
                    Debug.Log("hit something at: " + raycastHit2D.point);
                    vertex = raycastHit2D.point;
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
        }
    }
}