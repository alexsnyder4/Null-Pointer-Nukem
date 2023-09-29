using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullPointerSpawner : MonoBehaviour
{
    private float yRange;
    [SerializeField]
    public GameObject nullPointerPrefab;
    public int destroyDelay = 20;

    void Start()
    {
        StartCoroutine(SpawnNullPointerUniformDist(6, 10));
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
            Vector3 position;
            Vector3 direction;
            Quaternion rotation;
            if (UnityEngine.Random.Range(0, 2) == 0) // Randomly choose left or right
            {
                // Spawn on the left and flip along the vertical axis
                position = new Vector3(-53, yRange, 0);
                rotation = Quaternion.Euler(0, 180, 0);
                direction = Vector3.right;
            }
            else
            {
                // Spawn on the right
                position = new Vector3(53, yRange, 0);
                rotation = Quaternion.identity;
                direction = Vector3.left;
            }

            GameObject nullPointer = Instantiate(nullPointerPrefab, position, rotation);
            Rigidbody2D rb = nullPointer.GetComponent<Rigidbody2D>();

            // Adjust the speed by modifying the arrow's rigidbody velocity
            float speed = UnityEngine.Random.Range(4f, 8f); // Varying speed
            rb.velocity = direction * speed;
            Destroy(nullPointer, destroyDelay);
        }
    }
}
