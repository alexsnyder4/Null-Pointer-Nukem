using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullPointerSpawner : MonoBehaviour
{
    private float yRange;
    [SerializeField]
    public GameObject nullPointerPrefab;
    
    // Start is called before the first frame update
    IEnumerator SpawnNullPointer(float waitTime)
    {
        yRange = UnityEngine.Random.Range(14,-17);
        yield return new WaitForSeconds(waitTime);
        Vector3 position = new Vector3(53, yRange, 1);
        Instantiate(nullPointerPrefab, position,Quaternion.identity);
    }
    void Start()
    {
        StartCoroutine(SpawnNullPointerUniformDist(2, 10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnNullPointerUniformDist(float minTime, float maxTime)
    {
        while(true)
        {
            yRange = UnityEngine.Random.Range(14,-17);
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(53 ,yRange,0);
            Instantiate(nullPointerPrefab, position, Quaternion.identity);
        }
    }
}
