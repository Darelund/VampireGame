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

    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private ObjectPoolManager objectPoolManager;



    public void UpdateSpawner()
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
    //private void Spawn()
    //{
    //    Instantiate(spawnObject, GetSpawnPosition(), Quaternion.identity);
    //}
   
    //private IEnumerator SpawnCoroutine()
    //{
    //    var newEnemy = Instantiate(spawnObject, GetSpawnPosition(), Quaternion.identity);
    //    enemyManager.GetEnemiesList.Add(newEnemy);
    //    yield return new WaitForSeconds(spawnInterval);
    //}
    private IEnumerator SpawnCoroutine()
    {
        //Quick harsh solution
        //int rndNumber = Random.Range(0, 2);
        //string enemyToSpawn = rndNumber == 1 ? "Enemy1" : "Lyktgubbe";

        var newEnemy = objectPoolManager.GetObjectPools["Lyktgubbe"].UsePool();
        if (newEnemy == null) yield return null;
        newEnemy.transform.position = GetSpawnPosition();
        newEnemy.GetComponent<EnemyController>().InitializeEnemy();
       // var newEnemy = Instantiate(spawnObject, GetSpawnPosition(), Quaternion.identity);
        enemyManager.GetEnemiesList.Add(newEnemy);
        yield return new WaitForSeconds(spawnInterval);
    }
    private Vector2 GetSpawnPosition()
    {
        float XPos = Random.Range(-30, 30);
        float YPos = Random.Range(-30, 30);
        return new Vector2(XPos, YPos);
    }
}
