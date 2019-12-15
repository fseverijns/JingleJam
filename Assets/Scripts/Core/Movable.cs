using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public Vector3 Movement { get; set; }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    protected virtual void UpdateMovement()
    {
        Vector3 destination = transform.position + Movement;
        Vector3 newPosition = Vector3.Lerp(transform.position, destination, Time.deltaTime);
        transform.position = newPosition;

        Movement = Vector3.zero;
    }
}
