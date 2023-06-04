using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isRunning = false;

    [SerializeField] ScoreSO scoreHandler;
    [SerializeField] List<GameStageSO> gameStages;

    private GameStageSO currentGameStage;
    public GameStageSO GetCurrentGameStage() => currentGameStage;

    private UIManager uiManager;

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
        uiManager = GetComponent<UIManager>();
        uiManager.ActiveHomePanel();
        CalculateGameStage();
    }

    private void Update()
    {
        if (isRunning)
            scoreHandler.currentRunTime += 1 * Time.deltaTime;

        CalculateGameStage();
    }

    private void CalculateGameStage()
    {
        foreach (GameStageSO stageStats in gameStages)
            if (scoreHandler.currentRunTime >= stageStats.activationRunTime)
                currentGameStage = stageStats;
    }

    public void StartGame()
    {
        isRunning = true;
        scoreHandler.currentRunTime = 0;
    }

    public void EndGame()
    {
        isRunning = false;
        scoreHandler.CalculateHighScore();
        uiManager.ActiveEndGamePanel();
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
