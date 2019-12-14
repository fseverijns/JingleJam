using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movable
{
    [Header("ID")]
    [SerializeField]
    private int playerNum = 1;

    [Header("Movement")]
    [SerializeField]
    private float speed = 5;

    [Header("Pickup")]
    [SerializeField]
    private Vector3 pickupHeldPosition = new Vector3(0, 1, 0);
    [SerializeField]
    private Vector3 pickupDropPosition = new Vector3(0, 0, 1);
    private List<Pickup> pickupsInRange = new List<Pickup>();

    public Vector3 PickupHeldPosition { get => transform.position + pickupHeldPosition; }
    public Pickup CarryingPickup { get; private set; }

    public Vector3 ExternalMovement { get; set; }

    public Vector3 FacingDirection { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame    
    void Update()
    {
        UpdateMovement();

        if(Input.GetButtonDown("Player" + playerNum + "Pickup"))
        {
            if(CarryingPickup)
            {
                DropObject();
            }
            else
            {
                PickupObject();
            }
        }
    }

    protected override void UpdateMovement()
    {
        float horizontalMovement = Input.GetAxis("Player" + playerNum + "Horizontal");
        float verticalMovement = Input.GetAxis("Player" + playerNum + "Vertical");

        if(horizontalMovement != 0 || verticalMovement != 0)
        {
            if (Mathf.Abs(horizontalMovement) > Mathf.Abs(verticalMovement))
            {
                FacingDirection = new Vector3(Mathf.Sign(horizontalMovement), 0, 0);
            }
            else
            {
                FacingDirection = new Vector3(0, 0, Mathf.Sign(-verticalMovement));
            }
        }

        Vector3 destination = transform.position;

        destination = transform.position + Vector3.right * (horizontalMovement * speed);
        destination += Vector3.forward * -(verticalMovement * speed);

        destination += Movement;

        Vector3 newPosition = Vector3.Lerp(transform.position, destination, Time.deltaTime);
        transform.position = newPosition;
    }

    void PickupObject()
    {
        if (pickupsInRange.Count > 0)
        {
            Pickup closestPickup = pickupsInRange[0];

            if(pickupsInRange.Count > 1)
            {
                float closest = float.MaxValue;
                foreach(Pickup p in pickupsInRange)
                {
                    float dist = Vector3.Distance(transform.position, p.transform.position);
                    if (dist < closest)
                    {
                        closestPickup = p;
                        closest = dist;
                    }
                }
            }

            CarryingPickup = closestPickup;
            closestPickup.PickUp(this);
        }
    }

    void DropObject()
    {
        if(CarryingPickup)
        {
            CarryingPickup.Drop();
            CarryingPickup = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Pickup"))
        {
            Debug.Log("Pickup in Range");
            Pickup pickup = other.GetComponent<Pickup>();
            if(pickup != null)
            {
                pickupsInRange.Add(pickup);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Pickup"))
        {
            Debug.Log("Pickup out of Range");
            Pickup pickup = other.GetComponent<Pickup>();
            if (pickup != null)
            {
                pickupsInRange.Remove(pickup);
            }
        }
    }
}
