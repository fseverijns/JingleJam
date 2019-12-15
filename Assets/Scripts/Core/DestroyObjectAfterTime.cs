using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectAfterTime : MonoBehaviour
{

    [SerializeField]
    private float time = 10;
    private float timePassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= time)
        {
            Destroy(this.gameObject);
        }
    }
}
