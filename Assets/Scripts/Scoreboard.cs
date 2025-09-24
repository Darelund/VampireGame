using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private GameObject scorePrefab;
    [SerializeField] private GameObject scoreParent;

    private GameData _gameData;


    private void Start()
    {
        _gameData = LoadDataManager.Instance.gameData;
        DisplayScoreboard();
    }

    public void DisplayScoreboard()
    {
        if(_gameData == null)
        {
            Debug.LogError("GameData was null for some reason, therefore I can't display the scoreboard");
            return;
        }

        //I choose to order by experience points because why not. I should probably make an algorithm that uses xp, time and enemies killed
        var orderedGameData = _gameData.scores.ToList().OrderByDescending(sc => sc.ExperiencePoints).ToList();
        orderedGameData.ForEach(g => g.Rank = (orderedGameData.IndexOf(g) +  1));

        foreach (var score in orderedGameData) 
        {
            var scoreRow = Instantiate(scorePrefab, scoreParent.transform).GetComponent<ScoreboardRow>();
            scoreRow.rowRank.text = score.Rank.ToString();
            scoreRow.rowName.text = score.Name.ToString();
            scoreRow.rowExp.text = score.ExperiencePoints.ToString();
            scoreRow.rowWaves.text = score.Waves.ToString();
            scoreRow.rowLvl.text = score.Level.ToString();
            scoreRow.rowKills.text = score.EnemiesKilled.ToString();
            //scoreRow.rowTime.text = $"{score.Time.Minute}";
        }
    }
}
