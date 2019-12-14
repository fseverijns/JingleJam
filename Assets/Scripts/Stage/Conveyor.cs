using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Conveyor : MonoBehaviour
{
    [SerializeField]
    private Vector3 conveyorMovement;

    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RemoveFromConveyor(Movable movable)
    {
        movable.Movement = Vector3.zero;
    }

    private void OnTriggerStay(Collider other)
    {
        Movable movable = other.gameObject.GetComponent<Movable>();
        if (movable != null)
        {
            movable.Movement = conveyorMovement;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Movable movable = other.gameObject.GetComponent<Movable>();
        if (movable != null)
        {
            movable.Movement = Vector3.zero;
        }
    }
}
