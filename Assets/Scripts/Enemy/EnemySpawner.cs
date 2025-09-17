using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float startSpawn;
    [SerializeField] private float spawnInterval = 5;
    [SerializeField] private float currentSpawnTime;
    [SerializeField] private float spawnRadius;
    [SerializeField] private GameObject spawnObject;


    void Start()
    {
       // InvokeRepeating("Spawn", startSpawn, spawnInterval);
    }
    private void Update()
    {
        if(startSpawn > Time.time) return;

        Spawner();

    }
    private void Spawner()
    {
        currentSpawnTime += Time.deltaTime;
        if (currentSpawnTime > spawnInterval)
        {
            StartCoroutine("SpawnCoroutine");
            currentSpawnTime = 0;
        }
    }
    private void Spawn()
    {
        Instantiate(spawnObject, GetSpawnPosition(), Quaternion.identity);
    }
   
    private IEnumerator SpawnCoroutine()
    {
        Instantiate(spawnObject, GetSpawnPosition(), Quaternion.identity);
        yield return new WaitForSeconds(spawnInterval);
    }
    private Vector2 GetSpawnPosition()
    {
        float XPos = Random.Range(0, spawnRadius + 1);
        float YPos = Random.Range(0, spawnRadius + 1);
        return new Vector2(XPos, YPos);
    }
}
