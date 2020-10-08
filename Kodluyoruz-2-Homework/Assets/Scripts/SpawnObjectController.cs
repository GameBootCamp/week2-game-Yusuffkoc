using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectController : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private float spawnPointx1;
    [SerializeField] private float spawnPointx2;
    [SerializeField] private float dropHeight;


    [SerializeField] private List<GameObject> spawnObjects = new List<GameObject>();

    float spawnPoint;

    void Start()
    {
        StartCoroutine(SpawnObjects(waitTime));
    }

    
    void Update()
    {
        
    }

    private IEnumerator SpawnObjects(float spawnPeriod)
    {
        while (true)
        {
            WaitForSeconds wait = new WaitForSeconds(spawnPeriod);

            GameObject spawnGameObject = spawnObjects[Random.Range(0, spawnObjects.Count)];

            Instantiate(spawnGameObject, GetRandomSpawnPosition(), Quaternion.identity);

            yield return wait;
        }
        
        
        
        
    }
    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(spawnPointx1, spawnPointx2), dropHeight, 0);
    }
}
