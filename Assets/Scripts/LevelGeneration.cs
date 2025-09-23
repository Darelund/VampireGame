using System.Collections.Generic;
using UnityEngine;

//Dont spawn to many objects, will crash
public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private List<GameObject> environmentPrefabs;
    [SerializeField] private List<GameObject> spawnedObjects;



    [SerializeField] private float generationDistance;
    [SerializeField] private Vector2Int generateAmount;

    [SerializeField] private Vector2 generateOnY;
    [SerializeField] private Vector2 generateOnX;

    [SerializeField] private float despawnDistance;

    [SerializeField] private GameObject playerObject;
    private void Start()
    {
        GenerateLevel();
    }
    private void Update()
    {
        HandleLevel();
    }
    public void GenerateLevel()
    {
        int spawnAmount = Random.Range(generateAmount.x, generateAmount.y);

        for (int i = 0; i < spawnAmount; i++)
        {
            bool couldSpawnObject = false;

            while (!couldSpawnObject)
            {
                couldSpawnObject = true;
                Vector2 spawnPosition = GetSpawnPosition();



                foreach (var s in spawnedObjects)
                {
                    if (Vector2.Distance(s.transform.position, spawnPosition) < generationDistance)
                    {
                        couldSpawnObject = false;
                        break;
                    }
                }
                if (couldSpawnObject)
                {
                    int rdnObject = Random.Range(0, environmentPrefabs.Count);

                    GameObject g = Instantiate(environmentPrefabs[rdnObject], spawnPosition, Quaternion.identity);
                    spawnedObjects.Add(g);
                }
            }
        }
    }
    private Vector2 GetSpawnPosition()
    {
        var spawnX = Random.Range(generateOnX.x, generateOnX.y);
        var spawnY = Random.Range(generateOnY.x, generateOnY.y);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        return spawnPosition;
    }
    public void HandleLevel()
    {
        foreach (var g in spawnedObjects)
        {
            if (Vector2.Distance(playerObject.transform.position, g.transform.position) > despawnDistance)
            {
                g.SetActive(false);
            }
            else
            {
                g.SetActive(true);
            }
        }
    }



}
