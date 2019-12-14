using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Pickup : MonoBehaviour
{
    private SphereCollider sphereCollider;
    private bool pickedUpByPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp(Player player)
    {
        pickedUpByPlayer = true;
        sphereCollider.enabled = false;
        StartCoroutine(MoveToPlayer(player));
    }

    public void Drop(Player player)
    {
        pickedUpByPlayer = false;
        sphereCollider.enabled = true;
        StopCoroutine(MoveToPlayer(player));
    }

    private IEnumerator MoveToPlayer(Player player)
    {
        while(true)
        {
            transform.position = Vector3.Lerp(transform.position, player.PickupHeldPosition, Time.deltaTime * 10);
            if(Vector3.Distance(transform.position, player.PickupHeldPosition) < 0.1f)
            {
                transform.position = player.PickupHeldPosition;
                yield return null;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
