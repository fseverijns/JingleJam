using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> IcicleParents = new List<Transform>();
    [SerializeField]
    private Icicle IciclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform parent in IcicleParents)
        {
            BoxCollider col = parent.GetComponent<BoxCollider>();
            if(col)
            {
                Destroy(col);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnIcicles()
    {
        int amount = Random.Range(3, 5);
        for(int i = 0; i < amount; i++)
        {
            if(IcicleParents.Count < 1)
            {
                return;
            }

            int randomParentIndex = Random.Range(0, IcicleParents.Count);
            Transform icicleParent = IcicleParents[randomParentIndex];
            IcicleParents.Remove(icicleParent);

            Icicle newIcicle = Instantiate(IciclePrefab, icicleParent);
        }
    }
}
