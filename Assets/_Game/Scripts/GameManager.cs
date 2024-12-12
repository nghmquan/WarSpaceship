using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private LevelConfigSO levelConfigSO;
    [SerializeField] private MeteorSpawner meteorSpawner;

    private int curDifficultyIndex = 0;
    private int meteorHitCount = 0;


    private void Start()
    {
        InitMeteorSpawner();
    }

    void InitMeteorSpawner()
    {
        meteorSpawner.Initialize();
        meteorSpawner.SetSpeed(levelConfigSO.datas[curDifficultyIndex].gameSpeed);
        meteorSpawner.StartSpawnMeteor();
    }

    public void IncreaseMeteorHitCount()
    {
        meteorHitCount++;
        if (meteorHitCount >= levelConfigSO.datas[curDifficultyIndex].numOfMeteor)
        {
            curDifficultyIndex++;
            if (curDifficultyIndex>= levelConfigSO.datas.Count)
            {
                curDifficultyIndex = levelConfigSO.datas.Count;
            }
            meteorHitCount = 0;
            meteorSpawner.SetSpeed(levelConfigSO.datas[curDifficultyIndex].gameSpeed);
        }
        Debug.Log($"Difficulty : {curDifficultyIndex+1} - Meteor Hit: {meteorHitCount}");
    }
}
