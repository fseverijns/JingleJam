using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movable
{
    [Header("ID")]
    [SerializeField]
    public int playerNum = 1;

    [Header("Movement")]
    [SerializeField]
    private float speed = 5;

    [Header("Pickup")]
    [SerializeField]
    private Vector3 pickupHeldPosition = new Vector3(0, 1, 0);
    [SerializeField]
    private Vector3 pickupDropPosition = new Vector3(0, 0, 1);
    private List<Pickup> pickupsInRange = new List<Pickup>();
    private PickupInteracter interactorInRange;

    [Header("Respawn")]
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private float respawnDelay;

    public bool FreezePlayer { get; private set; }

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
        if(Input.GetButtonDown("Player" + playerNum + "Interact"))
        {
            if(CarryingPickup)
            {
                PlaceObjectOnInteracter();
            }
        }
    }

    protected override void UpdateMovement()
    {
        if(FreezePlayer)
        {
            return;
        }

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
                    if (p == null)
                    {
                        pickupsInRange.Remove(p);
                        continue;
                    }
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

    void PlaceObjectOnInteracter()
    {
        if (interactorInRange != null)
        {
            interactorInRange.Interact(this);
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

    public void Kill()
    {
        if(CarryingPickup)
        {
            Destroy(CarryingPickup.gameObject);
        }

        pickupsInRange.Clear();
        Invoke("Respawn", respawnDelay);
        gameObject.SetActive(false);
    }

    public void Respawn()
    {
        transform.position = spawnPoint.transform.position;
        gameObject.SetActive(true);
    }

    public void DestroyPickup()
    {
        Destroy(CarryingPickup);
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

        if (other.gameObject.tag.Equals("Interactable"))
        {
            PickupInteracter interactor = other.GetComponent<PickupInteracter>();
            if(interactor != null)
            {
                interactorInRange = interactor;
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
        if (other.gameObject.tag.Equals("Interactable"))
        {
            Debug.Log("Interactable out of Range");
            interactorInRange = null;
        }
    }
}
