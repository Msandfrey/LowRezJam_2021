using UnityEngine;

public class ShowInInspector : MonoBehaviour
{
    public Color color = Color.magenta;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, .5f);
    }
}
