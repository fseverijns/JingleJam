using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialButtonSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> buttonSpawnPositions = new List<Transform>();
    [SerializeField]
    private SpecialButton buttonPrefab;

    [SerializeField]
    private float minSpawnInterval = 30;
    [SerializeField]
    private float maxSpawnInterval = 60;

    [SerializeField]
    private GameObject spawnParticles;

    private float randomIntervalTime = 10000;
    private float timeElapsed = 0;

    private bool buttonInPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomIntervalTime();
    }

    // Update is called once per frame
    void Update()
    {
        if(!buttonInPlay)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= randomIntervalTime)
            {
                timeElapsed = 0f;
                SpawnButton();
            }
        }
    }

    private void SetRandomIntervalTime()
    {
        randomIntervalTime = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    public void SpawnButton()
    {
        int randomSpawnPositionIndex = Random.Range(0, buttonSpawnPositions.Count);
        Transform spawnPosition = buttonSpawnPositions[randomSpawnPositionIndex];
        Instantiate(buttonPrefab, spawnPosition.position, Quaternion.identity);
        buttonInPlay = true;
    }

    public void RemoveButton()
    {
        buttonInPlay = false;
        SetRandomIntervalTime();
    }
}
