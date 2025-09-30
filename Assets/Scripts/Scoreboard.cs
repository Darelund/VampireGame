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


        //Not sure if this is the right place to do this, but yeah
        //Can't have two people with the same name, that would be weird
        //So we remove the person with the least points
        // var duplicateNames = _gameData.scores.FindAll(s => s.Name == s.Name);



        //from, where, select, join, group, let, into, group join, multiple where
        //var duplicateNames = from s in _gameData.scores
        //                     where s.eq

        //List<Score> duplicateNames;
        //int duplicateCount;
        bool foundDuplicate = false;
        for (int i = 0; i < _gameData.scores.Count; i++)
        {
            for (int j = 0; j < _gameData.scores.Count; j++)
            {
                if (_gameData.scores[i].Name == _gameData.scores[j].Name && _gameData.scores[i] != _gameData.scores[j])
                {
                    if (_gameData.scores[i].ExperiencePoints > _gameData.scores[j].ExperiencePoints) _gameData.scores.Remove(_gameData.scores[j]);
                    else _gameData.scores.Remove(_gameData.scores[i]);

                    foundDuplicate = true;
                    break;
                }
            }
            if (foundDuplicate) break;
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
