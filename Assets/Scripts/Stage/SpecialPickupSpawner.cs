using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPickupSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> pickupSpawnPositions = new List<Transform>();
    [SerializeField]
    private List<Pickup> pickupPrefabs = new List<Pickup>();
    [SerializeField]
    private PickupList pickupList;
    [SerializeField]
    private GameObject pickupSpawnParticles;

    //Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFixedPickup()
    {
        int randomPositionIndex = Random.Range(0, pickupSpawnPositions.Count);
        Transform spawnPosition = pickupSpawnPositions[randomPositionIndex];

        int randomPickup = Random.Range(0, pickupPrefabs.Count);
        Pickup pickupPrefab = pickupPrefabs[randomPickup];

        pickupSpawnPositions.Remove(spawnPosition);

        Instantiate(pickupSpawnParticles, spawnPosition.position, Quaternion.identity);

        Pickup pickup = Instantiate(pickupPrefab, spawnPosition.position, Quaternion.identity);
        pickup.partState = PartStateEnum.Fixed;
        pickup.spriteRenderer.sprite = pickupList.GetFixedVersion(pickup);
    }
}
