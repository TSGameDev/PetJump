using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] ScoreSO scoreHandler;

    [Header("UI Panels")]
    [SerializeField] GameObject homePanelUI;
    [SerializeField] GameObject gamePanelUI;
    [SerializeField] GameObject endGamePanelUI;

    [Header("Text Elements")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreTextHome;
    [SerializeField] TextMeshProUGUI highScoreTextEndGame;
    [SerializeField] TextMeshProUGUI differenceToHighScoreText;

    private void Update()
    {
        scoreText.text = $"Score: {scoreHandler.currentRunTime}";
    }

    public void ActiveHomePanel()
    {
        highScoreTextHome.text = $"Current High Score: {scoreHandler.highestRunTime}";

        homePanelUI.SetActive(true);
        gamePanelUI.SetActive(false);
        endGamePanelUI.SetActive(false);
    }

    public void ActiveGamePanel()
    {
        homePanelUI.SetActive(false);
        gamePanelUI.SetActive(true);
        endGamePanelUI.SetActive(false);
    }

    public void ActiveEndGamePanel()
    {
        highScoreTextEndGame.text = $"You Lasted\r\n{scoreHandler.currentRunTime}\r\nSeconds";

        int difbetweenScores = (int)(scoreHandler.highestRunTime - scoreHandler.currentRunTime);
        if(difbetweenScores <= 0)
            differenceToHighScoreText.text = $"NEW HIGH SCORE";
        else
            differenceToHighScoreText.text = $"You were {difbetweenScores} Seconds away from a new high score";

        homePanelUI.SetActive(false);
        gamePanelUI.SetActive(false);
        endGamePanelUI.SetActive(true);
    }
}
