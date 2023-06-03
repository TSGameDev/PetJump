using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public bool isRunning = false;
    public float currentRunTime = 0;
    public float highestRunTime;

    [SerializeField] List<GameStageStats> gameStages;
    [HideInInspector] private GameStageStats CurrentGameStats;

    private ObstacleCreation obstacleCreation;

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        obstacleCreation = GetComponent<ObstacleCreation>();
        highestRunTime = PlayerPrefs.GetFloat("High Score");
        UIManager.Instance.ActiveHomePanel();
    }

    private void Update()
    {
        if (isRunning)
            currentRunTime += 1 * Time.deltaTime;

        CalculateGameStage();
    }

    private void CalculateGameStage()
    {
        foreach (GameStageStats stageStats in gameStages)
        {
            if (currentRunTime >= stageStats.activationRunTime)
            {
                CurrentGameStats = stageStats;
                obstacleCreation.obstacleSpeed = CurrentGameStats.stageObstacleSpeed;
                obstacleCreation.obstacleMinSpawnInterval = CurrentGameStats.stageMinObstacleSpawnInterval;
                obstacleCreation.obstacleMaxSpawnInterval = CurrentGameStats.stageMaxObstacleSpawnInterval;
            }
        }
    }

    public void StartGame()
    {
        isRunning = true;
        currentRunTime = 0;
    }

    public void EndGame()
    {
        isRunning = false;
        if(currentRunTime > highestRunTime)
        {
            highestRunTime = currentRunTime;
            PlayerPrefs.SetFloat("High Score", highestRunTime);
        }
        UIManager.Instance.ActiveEndGamePanel();
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
