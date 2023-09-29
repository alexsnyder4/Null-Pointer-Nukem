using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateSpawner : MonoBehaviour
{

    [SerializeField]
    public GameObject piratePrefab;
    private GameObject playerObject;
    public float playerRadius = 20f;
    public float spriteSize = 5f;
    float cameraHeight;
    float cameraWidth;
    Camera mainCamera;
    public float destroyDelay = 5;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        mainCamera = Camera.main;
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;
        StartCoroutine(SpawnPirateUniformDist(4, 10));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnPirateUniformDist(float minTime, float maxTime)
    {
        while(true)
        {
            
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            Vector2 cameraMin = (Vector2)mainCamera.transform.position - new Vector2(cameraWidth / 2, cameraHeight / 2);
            Vector2 cameraMax = (Vector2)mainCamera.transform.position + new Vector2(cameraWidth / 2, cameraHeight / 2);
            Vector2 spawnAreaMin = cameraMin + new Vector2(10.0f, 10.0f); // Adjust as needed
            Vector2 spawnAreaMax = cameraMax - new Vector2(10.0f, 10.0f); // Adjust as needed
            Vector2 randomSpawnPosition; //= new Vector2(Random.Range(spawnAreaMin.x, spawnAreaMax.x), Random.Range(spawnAreaMin.y, spawnAreaMax.y));
            do
            {
                randomSpawnPosition = new Vector2(Random.Range(spawnAreaMin.x, spawnAreaMax.x), Random.Range(spawnAreaMin.y, spawnAreaMax.y));
            } while (
                Vector2.Distance(randomSpawnPosition, playerObject.transform.position) <= playerRadius
            );
            GameObject pirate = Instantiate(piratePrefab, randomSpawnPosition, Quaternion.identity);

            Destroy(pirate,destroyDelay);

            yield return new WaitForSeconds(waitTime);
        }
    }
}
