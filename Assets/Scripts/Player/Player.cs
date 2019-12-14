using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

    public Vector3 PickupHeldPosition { get => transform.position + pickupHeldPosition; }

    private List<Pickup> pickupsInRange = new List<Pickup>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame    
    void Update()
    {
        UpdateMovement();

        if(Input.GetButtonDown("Player" + playerNum + "Interact"))
        {
            Debug.Log("Pickup!");
            PickupObject();
        }
    }

    void UpdateMovement()
    {
        float horizontalMovement = Input.GetAxis("Player" + playerNum + "Horizontal");
        float verticalMovement = Input.GetAxis("Player" + playerNum + "Vertical");

        Vector3 destination = transform.position;

        destination = transform.position + Vector3.right * (horizontalMovement * speed);
        destination += Vector3.forward * -(verticalMovement * speed);

        Vector3 newPosition = Vector3.Lerp(transform.position, destination, Time.deltaTime);
        transform.position = newPosition;
    }

    void PickupObject()
    {
        if (pickupsInRange.Count > 0)
        {
            pickupsInRange[0].PickUp(this);
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
