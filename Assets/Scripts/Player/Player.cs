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
    private Pickup closestPickup;
    private PickupInteracter interactorInRange;

    [Header("Respawn")]
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private float respawnDelay;

    [SerializeField]
    private AudioSource walkingSound;
    [SerializeField]
    private AudioSource pickupItemSound;
    [SerializeField]
    private AudioSource dropItemSound;

    [SerializeField]
    private List<AudioSource> taunts;
    [SerializeField]
    private float tauntCooldown = 3f;
    private float currentTauntCooldown = 0f;
    private bool tauntOnCooldown = false;
    
    [SerializeField]
    private GameObject deathParticles;
    [SerializeField]
    private GameObject respawnParticles;

    private Animator anim;

    public bool PlayerFrozen { get; private set; }

    public Vector3 PickupHeldPosition { get => transform.position + pickupHeldPosition; }
    public Pickup CarryingPickup { get; private set; }

    public Vector3 ExternalMovement { get; set; }

    public Vector3 FacingDirection;
    public int FacingDirectionParam;
    public bool PlayerIsMoving;

    private bool walkingSoundIsPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame    
    void FixedUpdate()
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
                Interact();
            }
        }

        if(Input.GetButtonDown("Player" + playerNum + "Taunt"))
        {
            Taunt();
        }

        if (tauntOnCooldown)
        {
            if (currentTauntCooldown < tauntCooldown)
            {
                currentTauntCooldown += Time.deltaTime;
            }
            else
            {
                tauntOnCooldown = false;
                currentTauntCooldown = 0;
            }
        }
    }

    private void LateUpdate()
    {
        UpdatePickups();
        UpdateInteractor();
    }

    protected override void UpdateMovement()
    {
        if(PlayerFrozen)
        {
            return;
        }

        float horizontalMovement = Input.GetAxis("Player" + playerNum + "Horizontal");
        float verticalMovement = Input.GetAxis("Player" + playerNum + "Vertical");

        if(horizontalMovement != 0 || verticalMovement != 0)
        {
            PlayWalkingSound();
            if (Mathf.Abs(horizontalMovement) > Mathf.Abs(verticalMovement))
            {
                FacingDirection = new Vector3(Mathf.Sign(horizontalMovement), 0, 0);
            }
            else
            {
                FacingDirection = new Vector3(0, 0, Mathf.Sign(-verticalMovement));
            }
            PlayerIsMoving = true;
        }
        else
        {
            if (walkingSound.isPlaying)
            {
                walkingSound.Stop();
                StopCoroutine(WalkingSoundTimer());
                walkingSoundIsPlaying = false;
            }

            PlayerIsMoving = false;
            FacingDirection = new Vector3(0, 0, -1);
        }

        if(FacingDirection.x < 0) // left
        {
            FacingDirectionParam = 0;
        }
        else if(FacingDirection.x > 0) // right
        {
            FacingDirectionParam = 1;
        }
        else if(FacingDirection.z < 0) // down
        {
            FacingDirectionParam = 2;
        }
        else if(FacingDirection.z > 0) // up
        {
            FacingDirectionParam = 3;
        }
        else // default
        {
            FacingDirectionParam = 2;
        }

        Vector3 destination = transform.position;

        destination = transform.position + transform.right * (horizontalMovement * speed);
        destination += transform.forward * -(verticalMovement * speed);

        destination += Movement;

        Vector3 newPosition = Vector3.Lerp(transform.position, destination, Time.deltaTime);
        transform.position = newPosition;

        if(anim)
        {
            anim.SetBool("PlayerIsMoving", PlayerIsMoving);
            anim.SetInteger("FacingDirectionParam", FacingDirectionParam);
        }
    }

    private void PlayWalkingSound()
    {
        if (walkingSoundIsPlaying == false)
        {
            walkingSoundIsPlaying = true;
            walkingSound.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
            walkingSound.reverbZoneMix = UnityEngine.Random.Range(0.7f, 1.1f);
            walkingSound.Play();

            StartCoroutine(WalkingSoundTimer());
        }
    }

    private IEnumerator WalkingSoundTimer()
    {
        yield return new WaitForSeconds(walkingSound.clip.length);
        walkingSoundIsPlaying = false;
    }

    void UpdatePickups()
    {
        if(CarryingPickup)
        {
            return;
        }

        if (pickupsInRange.Count > 0)
        {
            closestPickup = pickupsInRange[0];

            if (pickupsInRange.Count > 1)
            {
                float closest = float.MaxValue;
                foreach (Pickup p in pickupsInRange)
                {
                    if (p == null)
                    {
                        pickupsInRange.Remove(p);
                        continue;
                    }

                    if(p.PickedUpByPlayer)
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

            closestPickup.TogglePrompt(true);
        }
    }

    void UpdateInteractor()
    {
        if(interactorInRange != null)
        {
            interactorInRange.TogglePrompt(this, true);
        }
    }

    void PickupObject()
    {
        if(PlayerFrozen)
        {
            return;
        }

        if (closestPickup != null)
        {
            pickupItemSound.Play();
            pickupsInRange.Remove(closestPickup);
            CarryingPickup = closestPickup;
            CarryingPickup.PickUp(this);
            closestPickup = null;
        }         
    }

    void Interact()
    {
        if (PlayerFrozen)
        {
            return;
        }

        if (interactorInRange != null)
        {
            interactorInRange.Interact(this);
        }
    }

    void DropObject()
    {
        if (PlayerFrozen)
        {
            return;
        }

        if (CarryingPickup)
        {
            dropItemSound.Play();
            CarryingPickup.Drop();
            CarryingPickup = null;
        }
    }

    public void FreezePlayer()
    {
        PlayerFrozen = true;
    }

    public void UnFreezePlayer()
    {
        PlayerFrozen = false;
    }

    private void Taunt()
    {
        if (tauntOnCooldown == false)
        {
            int audioSourceToPlay = Random.Range(0, taunts.Count);
            taunts[audioSourceToPlay].Play();

            tauntOnCooldown = true;
        }
    }

    public void Kill()
    {
        if(CarryingPickup)
        {
            Destroy(CarryingPickup.gameObject);
        }

        if(closestPickup != null)
        {
            closestPickup.TogglePrompt(false);
        }
        if(interactorInRange != null)
        {
            interactorInRange.TogglePrompt(this, false);
        }

        pickupsInRange.Clear();

        Instantiate(deathParticles, transform.position, Quaternion.identity);

        Invoke("Respawn", respawnDelay);
        GameScreen.Instance.MakePlayerUITransparent(playerNum);
        gameObject.SetActive(false);
    }

    public void Respawn()
    {
        Instantiate(respawnParticles, transform.position, Quaternion.identity);
        transform.position = spawnPoint.transform.position;
        GameScreen.Instance.MakePlayerUISolid(playerNum);
        gameObject.SetActive(true);
    }

    public void DestroyPickup()
    {
        pickupsInRange.Remove(CarryingPickup);
        Destroy(CarryingPickup.gameObject);
        CarryingPickup = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Pickup"))
        {
            Debug.Log("Pickup in Range", this.gameObject);
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
                pickup.TogglePrompt(false);
                pickupsInRange.Remove(pickup);
            }
        }
        if (other.gameObject.tag.Equals("Interactable"))
        {
            Debug.Log("Interactable out of Range");
            if(interactorInRange != null)
            {
                interactorInRange.TogglePrompt(this, false);
            }
            interactorInRange = null;
        }
    }
}
