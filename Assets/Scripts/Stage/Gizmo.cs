using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public Color color = Color.red;

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = color;
        Vector3 position = new Vector3(transform.position.x, 0, transform.position.z);
        Gizmos.DrawSphere(position, 0.5f);
    }
}
