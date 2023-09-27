using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmSpawner : MonoBehaviour
{
    private float yRange;
    [SerializeField]
    public GameObject swarmSpawnerPrefab;
    
    // Start is called before the first frame update
    IEnumerator SpawnSwarmUniformDist(float minTime, float maxTime)
    {
        while(true)
        {
            yRange = UnityEngine.Random.Range(14,-17);
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position = new Vector3(53 ,yRange,0);
            Instantiate(swarmSpawnerPrefab, position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSwarmUniformDist(2, 10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
