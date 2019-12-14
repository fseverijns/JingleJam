using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Pickup : Movable
{
    private SphereCollider sphereCollider;
    private Player currentOwner;
    private bool snapToPlayer = false;

    public Vector3 ExternalMovement { get; set; }
    public bool PickedUpByPlayer { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if(snapToPlayer && currentOwner != null)
        {
            transform.position = currentOwner.PickupHeldPosition;
        }
        else if(snapToPlayer)
        {
            snapToPlayer = false;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        UpdateMovement();
    }

    protected override void UpdateMovement()
    {
        if(!PickedUpByPlayer)
        {
            base.UpdateMovement();
        }
    }

    public void PickUp(Player player)
    {
        if(PickedUpByPlayer)
        {
            return;
        }

        currentOwner = player;
        PickedUpByPlayer = true;
        sphereCollider.enabled = false;
        StopAllCoroutines();
        StartCoroutine(MoveToPlayer());
    }

    public void Drop()
    {
        PickedUpByPlayer = false;
        snapToPlayer = false;
        sphereCollider.enabled = true;
        StopAllCoroutines();
        StartCoroutine(MoveToDropPosition());
    }

    private IEnumerator MoveToPlayer()
    {
        while(true)
        {
            transform.position = Vector3.Lerp(transform.position, currentOwner.PickupHeldPosition, Time.deltaTime * 10);
            if(Vector3.Distance(transform.position, currentOwner.PickupHeldPosition) < 0.1f)
            {
                transform.position = currentOwner.PickupHeldPosition;
                snapToPlayer = true;
                break;
            }
            yield return null;
        }
    }

    private IEnumerator MoveToDropPosition()
    {
        Vector3 destination = currentOwner.transform.position + (currentOwner.FacingDirection * 1.5f);
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * 10);
            if(Vector3.Distance(transform.position, destination) < 0.1f)
            {
                transform.position = destination;
                currentOwner = null;
                break;
            }
            yield return null;
        }
        yield return null;
    }
}
