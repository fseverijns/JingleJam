using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialButton : MonoBehaviour
{
    [SerializeField]
    private GameObject despawnParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeState()
    {
        //change visual
        Invoke("DestroySelf", 2.0f);
    }

    private void DestroySelf()
    {
        Instantiate(despawnParticles, transform.position, Quaternion.identity);
        FindObjectOfType<SpecialButtonSpawner>().RemoveButton();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player)
        {
            FindObjectOfType<IcicleSpawner>().SpawnIcicles();
            FindObjectOfType<SpecialPickupSpawner>().SpawnFixedPickup();

            ChangeState();
        }
    }
}
