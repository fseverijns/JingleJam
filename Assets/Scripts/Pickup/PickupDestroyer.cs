using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.isTrigger)
        {
            return;
        }

        Pickup pickup = other.gameObject.GetComponent<Pickup>();
        if(pickup != null)
        {
            if(pickup.PickedUpByPlayer)
            {
                return;
            }
            Destroy(pickup.gameObject);
        }
    }
}
