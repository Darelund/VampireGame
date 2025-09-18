using System.Collections.Generic;
using UnityEngine;

public class VisualManager : MonoBehaviour
{
    private static VisualManager instance;
    [SerializeField] private List<GameObject> textPrefabs;


    public static VisualManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnText("Test", Vector2.zero, TextType.Normal);
    }
    public void SpawnText(string text, Vector2 spawnPos, TextType textType)
    {
        var spawnedText = Instantiate(textPrefabs.Find(t => t.GetComponent<FeedbackText>().TextType == textType).gameObject, spawnPos, Quaternion.identity);
        spawnedText.GetComponent<FeedbackText>().Initialize(text);
    }
    public void SpawnText(string text, Vector2 spawnPos, TextType textType, Color newColor)
    {
        var spawnedText = Instantiate(textPrefabs.Find(t => t.GetComponent<FeedbackText>().TextType == textType).gameObject, spawnPos, Quaternion.identity);
        spawnedText.GetComponent<FeedbackText>().Initialize(text, newColor);
    }
}
