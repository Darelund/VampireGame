using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private float startSpawn;
    //[SerializeField] private float spawnInterval = 5;
    [SerializeField] private float currentSpawnTime;
    [SerializeField] private float spawnRadius;
    //[SerializeField] private GameObject spawnObject;

    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private ObjectPoolManager objectPoolManager;

    //Maybe use in future
    //[SerializeField] private AnimationCurve difficultyCurve;


    [SerializeField] private int currentWave = 1;
    [SerializeField] private List<WaveData> WaveData;

    public WaveData GetCurrentWave
    {
        get
        {
            return WaveData[WaveData.Count - 1];
        }

    }


    public void UpdateSpawner()
    {
        if(startSpawn > Time.time) return;

        if (WaveData[currentWave - 1].IsWaveOver()) return;

        Spawner();
    }
    private void Spawner()
    {
        currentSpawnTime += Time.deltaTime;
        if (currentSpawnTime > WaveData[currentWave - 1].SpawnInterval)
        {
            StartCoroutine("SpawnCoroutine");
            currentSpawnTime = 0;
        }
    }
    private IEnumerator SpawnCoroutine()
    {
        //Quick harsh solution
        //int rndNumber = Random.Range(0, 2);
        //string enemyToSpawn = rndNumber == 1 ? "Enemy1" : "Lyktgubbe";

      // if( WaveData[currentWave - 1].IsWaveOver()) yield break;


        //var newEnemy = objectPoolManager.GetPools.ToList().Find(p => p.Name == WaveData[currentWave - 1].EnemyAmount[WaveData[currentWave - 1].CurrentEnemyAmountToUse()].EnemyPool).ObjectPool.UsePool();

        var nameOfPool = WaveData[currentWave - 1].EnemyAmount[WaveData[currentWave - 1].CurrentEnemyAmountToUse()].EnemyPool;
            var newEnemy = objectPoolManager.GetPools.ToList().Find(p => p.Name == nameOfPool).ObjectPool.UsePool();

            //var newEnemy = objectPoolManager.GetPools.ToList().Find(p => p.Name == "MeleeLyktgubbePool").ObjectPool.UsePool();
            if (newEnemy == null) yield return null;
            newEnemy.transform.position = GetSpawnPosition();

            //We don't create a new instance, we use an objectpool, so we need to reset the enemies stats
            newEnemy.GetComponent<EnemyController>().ResetEnemy();
            // var newEnemy = Instantiate(spawnObject, GetSpawnPosition(), Quaternion.identity);
            enemyManager.GetEnemiesList.Add(newEnemy.gameObject);
            yield return new WaitForSeconds(WaveData[currentWave - 1].SpawnInterval);
        
    }
    private Vector2 GetSpawnPosition()
    {
        float XPos = Random.Range(-30, 30);
        float YPos = Random.Range(-30, 30);
        return new Vector2(XPos, YPos);
    }
}
[System.Serializable]
public class WaveData
{
    public float SpawnInterval;
    public float DifficultyMultiplier;
    
    public List<EnemyAmount> EnemyAmount;
    //public bool WaveIsRunning;

    public bool IsWaveOver()
    {
        int current = EnemyAmount[EnemyAmount.Count - 1].CurrentlySpawned;
        int max = EnemyAmount[EnemyAmount.Count - 1].MaxAmountToSpawn;

        Debug.Log("Current: " + current);
        Debug.Log("max: " + max);
        return current >= max;
    }

    public int CurrentEnemyAmountToUse()
    {
        for (int i = 0; i < EnemyAmount.Count; i++)
        {
            if (EnemyAmount[i].CurrentlySpawned < EnemyAmount[i].MaxAmountToSpawn)
            {
                EnemyAmount[i].CurrentlySpawned++;
                return i;
            }
        }
        //WaveIsRunning = false;
        return -1; //No pools left to use
    }
}

[System.Serializable]
public class EnemyAmount //Can't come up with a good name
{
    public string EnemyPool;
    public int CurrentlySpawned;
    public int MaxAmountToSpawn;

}
