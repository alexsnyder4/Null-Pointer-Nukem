using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendantSpawner : MonoBehaviour
{
    public GameObject pendantPrefab;
    private GameObject playerObject;
    public float playerRadius = 10f;
    public float spriteSize = 5f;
    float cameraHeight;
    float cameraWidth;
    Camera mainCamera;
    public int numPendant = 0;
    public float destroyDelay = 6;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        mainCamera = Camera.main;
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;
        StartCoroutine(SpawnPendantUniformDist(4, 10));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnPendantUniformDist(float minTime, float maxTime)
    {
        while(true)
        {
            
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            Vector2 cameraMin = (Vector2)mainCamera.transform.position - new Vector2(cameraWidth / 2, cameraHeight / 2);
            Vector2 cameraMax = (Vector2)mainCamera.transform.position + new Vector2(cameraWidth / 2, cameraHeight / 2);
            Vector2 spawnAreaMin = cameraMin + new Vector2(2.0f, 2.0f); // Adjust as needed
            Vector2 spawnAreaMax = cameraMax - new Vector2(2.0f, 2.0f); // Adjust as needed
            Vector2 randomSpawnPosition; //= new Vector2(Random.Range(spawnAreaMin.x, spawnAreaMax.x), Random.Range(spawnAreaMin.y, spawnAreaMax.y));
            do
            {
                randomSpawnPosition = new Vector2(Random.Range(spawnAreaMin.x, spawnAreaMax.x), Random.Range(spawnAreaMin.y, spawnAreaMax.y));
            } while (
                Vector2.Distance(randomSpawnPosition, playerObject.transform.position) <= playerRadius
            );
            GameObject pendant = Instantiate(pendantPrefab, randomSpawnPosition, Quaternion.identity);
            numPendant++;

            DestroyPendant(destroyDelay,pendant);

            while(numPendant > 3)
            {
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
    void DestroyPendant(float delay,GameObject pendant)
    {
        Destroy(pendant,destroyDelay);
            numPendant--;
    }
}
