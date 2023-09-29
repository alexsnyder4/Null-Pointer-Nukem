using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmSpawner : MonoBehaviour
{
    private float yRange;
    [SerializeField]
    public GameObject swarmSpawnerPrefab;
    public int destroyDelay = 20;
    
    // Start is called before the first frame update
    IEnumerator SpawnSwarmUniformDist(float minTime, float maxTime)
    {
        while(true)
        {
            yRange = UnityEngine.Random.Range(14,-17);
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 position;
            Vector3 direction;
            Quaternion rotation;
            if (UnityEngine.Random.Range(0, 2) == 0) // Randomly choose left or right
            {
                // Spawn on the left and flip along the vertical axis
                position = new Vector3(-53, yRange, 0);
                rotation = Quaternion.Euler(0, 0, 0);
                direction = Vector3.right;
            }
            else
            {
                // Spawn on the right
                position = new Vector3(53, yRange, 0);
                rotation = Quaternion.Euler(0, 180, 0);
                direction = Vector3.left;
            }

            GameObject swarm = Instantiate(swarmSpawnerPrefab, position, rotation);
            Rigidbody2D rb = swarm.GetComponent<Rigidbody2D>();

            // Adjust the speed by modifying the arrow's rigidbody velocity
            float speed = UnityEngine.Random.Range(15f, 25f); // Varying speed
            rb.velocity = direction * speed;
            Destroy(swarm, destroyDelay);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSwarmUniformDist(4, 7));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
