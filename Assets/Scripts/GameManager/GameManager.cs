using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct GameStageStats
{
    public float activationRunTime;
    public float stageObstacleSpeed;
    public float stageMinObstacleSpawnInterval;
    public float stageMaxObstacleSpawnInterval;

    public GameStageStats(float activationRunTime, float stageObstacleSpeed, float stageMinObstacleSpawnInterval, float stageMaxObstacleSpawnInterval)
    {
        this.activationRunTime = activationRunTime;
        this.stageObstacleSpeed = stageObstacleSpeed;
        this.stageMinObstacleSpawnInterval = stageMinObstacleSpawnInterval;
        this.stageMaxObstacleSpawnInterval = stageMaxObstacleSpawnInterval;
    }
}

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameStageStats> gameStages;
    [HideInInspector] public GameStageStats CurrentGameStats;

    private bool isRunning = false;
    private float currentRunTime = 0;

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    void Update()
    {
        if (isRunning)
            currentRunTime = 1 * Time.deltaTime;
        CalculateGameStage();
    }

    private void CalculateGameStage()
    {
        foreach (GameStageStats stageStats in gameStages)
        {
            if (currentRunTime >= stageStats.activationRunTime)
                CurrentGameStats = stageStats;
        }
    }
}
