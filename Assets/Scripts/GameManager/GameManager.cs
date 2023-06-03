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
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] List<GameStageStats> gameStages;
    [HideInInspector] public GameStageStats CurrentGameStats;

    private ObstacleCreation obstacleCreation;

    private bool isRunning = false;
    private float currentRunTime = 0;
    private float highestRunTime = 0;

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
        highestRunTime = PlayerPrefs.GetFloat("High Score", 0);
    }

    private void Update()
    {
        if (isRunning)
            currentRunTime = 1 * Time.deltaTime;

        scoreTxt.text = $"Score: {(int)currentRunTime}";
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
        obstacleCreation.shouldCalculateObstacles = true;
    }

    public void EndGame()
    {
        isRunning = false;
        obstacleCreation.shouldCalculateObstacles = false;
        if(currentRunTime > highestRunTime)
            highestRunTime = currentRunTime;
    }

    public void CloseGame()
    {
        PlayerPrefs.SetFloat("High Score", highestRunTime);
        Application.Quit();
    }
}
