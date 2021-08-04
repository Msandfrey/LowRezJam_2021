using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInInspector : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position, .5f);
    }
}
