using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Pickup> spawnList = new List<Pickup>();

    [SerializeField]
    private float spawnInterval = 2f;

    [SerializeField]
    private float randomIntervalOffset = 1f;

    private bool spawnAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomPickup());
        AllowSpawn(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AllowSpawn(bool allowed)
    {
        spawnAllowed = allowed;
    }

    private IEnumerator SpawnRandomPickup()
    {
        while(true)
        {
            if(spawnAllowed)
            {
                if (spawnList.Count > 0)
                {
                    int randomIndex = Random.Range(0, spawnList.Count - 1);
                    Instantiate(spawnList[randomIndex], transform.position, Quaternion.identity);
                }

                float waitTime = spawnInterval + Random.Range(-randomIntervalOffset, randomIntervalOffset);
                yield return new WaitForSeconds(waitTime);
            }
            yield return null;
        }
    }
}
