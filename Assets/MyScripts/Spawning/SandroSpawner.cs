using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandroSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject sandroPrefab;
    private GameObject playerObject;
    public float playerRadius = 10f;
    public float spriteSize = 5f;
    float cameraHeight;
    float cameraWidth;
    Camera mainCamera;
    public float destroyDelay = 8;
    public float delay = 12;
    public bool initDelay = true;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        mainCamera = Camera.main;
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;
        StartCoroutine(SpawnSandroUniformDist(12, 20, 12));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnSandroUniformDist(float minTime, float maxTime, float delay)
    {
        
        if(initDelay == true)
        {
            initDelay = false;
            yield return new WaitForSeconds(delay);
        }
        while(true)
        {
            float waitTime = UnityEngine.Random.Range(minTime, maxTime);
            Vector2 cameraMin = (Vector2)mainCamera.transform.position - new Vector2(cameraWidth / 2, cameraHeight / 2);
            Vector2 cameraMax = (Vector2)mainCamera.transform.position + new Vector2(cameraWidth / 2, cameraHeight / 2);
            Vector2 spawnAreaMin = cameraMin + new Vector2(2.0f, 2.0f); // Adjust as needed
            Vector2 spawnAreaMax = cameraMax - new Vector2(2.0f, 2.0f); // Adjust as needed
            Vector2 randomSpawnPosition; 
            do
            {
                randomSpawnPosition = new Vector2(Random.Range(spawnAreaMin.x, spawnAreaMax.x), Random.Range(spawnAreaMin.y, spawnAreaMax.y));
            } while (
                Vector2.Distance(randomSpawnPosition, playerObject.transform.position) <= playerRadius
            );
            GameObject sandro = Instantiate(sandroPrefab, randomSpawnPosition, Quaternion.identity);
            
            Destroy(sandro,destroyDelay);

            yield return new WaitForSeconds(waitTime);
            
        }
    }
}
