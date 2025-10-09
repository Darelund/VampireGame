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
    private const int MAXSCORES = 10;


    private void Start()
    {
        _gameData = LoadDataManager.Instance.gameData;
        DisplayScoreboard();
    }

    public void DisplayScoreboard()
    {
        if(_gameData == null)
        {
            Debug.Log("GameData was null(Either no score has been saved or something went wrong), therefore I can't display the scoreboard");
            return;
        }


        //Not sure if this is the right place to do this, but yeah
        //Can't have two people with the same name, that would be weird
        //So we remove the person with the least points
        List<Score> duplicateScores = FindDuplicates();
        RemoveDuplicates(duplicateScores);


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
    private List<Score> FindDuplicates()
    {
        List<Score> duplicateScores = new List<Score>();

        for (int i = 0; i < _gameData.scores.Count; i++)
        {
            for (int j = 0; j < _gameData.scores.Count; j++)
            {
                if (_gameData.scores[i].Name == _gameData.scores[j].Name && _gameData.scores[i] != _gameData.scores[j])
                {
                    //if (_gameData.scores[i].ExperiencePoints > _gameData.scores[j].ExperiencePoints) _gameData.scores.Remove(_gameData.scores[j]);
                    //else _gameData.scores.Remove(_gameData.scores[i]);
                   
                    duplicateScores.Add(_gameData.scores[i]);
                }
            }
        }
        return duplicateScores;
    }
    private void RemoveDuplicates(List<Score> duplicateScores)
    {
        if(duplicateScores.Count <= 0)
        {
            //Should not run this code if there is no duplicates to remove
            return;
        }
        Score highestValueScore = FindHighestHighscorerOfDuplicate(duplicateScores);
        for (int i = 0; i < duplicateScores.Count; i++)
        {
            if(highestValueScore != duplicateScores[i])
            _gameData.scores.Remove(duplicateScores[i]);
        }
        duplicateScores.Clear();
        //_gameData.scores.remove
    }
    private Score FindHighestHighscorerOfDuplicate(List<Score> duplicateScores)
    {
        Score highestValueScore = null;
        for (int i = 0; i < duplicateScores.Count; i++)
        {
            for (int j = 0; j < duplicateScores.Count; j++)
            {
                if (highestValueScore == null)
                {
                    highestValueScore = duplicateScores[i];
                    continue;
                }

                if (highestValueScore.ExperiencePoints < duplicateScores[j].ExperiencePoints)
                {
                    highestValueScore = duplicateScores[j];
                }

                //If the experience points are the same then we will also use enemies killed as a way to decide which score will stay and which will get removed
                if (highestValueScore.ExperiencePoints == duplicateScores[j].ExperiencePoints)
                {
                    if (highestValueScore.EnemiesKilled < duplicateScores[j].EnemiesKilled)
                    {
                        highestValueScore = duplicateScores[j];
                    }
                }
            }
        }
        return highestValueScore;
    }
}
