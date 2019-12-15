using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    [SerializeField]
    private Collider theCollider;
    [SerializeField]
    private KillPlayerOnTouch killOnTouch;
    [SerializeField]
    private PickupDestroyer pickupDestroyer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CrashIcicle()
    {
        Debug.Log("Destroy things");
        theCollider.isTrigger = false;
        Destroy(killOnTouch);
        Destroy(pickupDestroyer);
    }
}
