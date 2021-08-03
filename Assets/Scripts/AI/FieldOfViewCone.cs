using System.Collections;
using UnityEngine;

namespace IndieWizards.AI
{
    public class FieldOfViewCone : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Mesh mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;

            float fov = 90f;
            Vector3 origin = transform.parent.position;
            int rayCount = 40;
            float angle = 0f;
            float angleIncrease = fov / rayCount;
            float viewDistance = 5f;

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
                RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)), viewDistance);
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

        // Update is called once per frame
        void Update()
        {

        }
    }
}