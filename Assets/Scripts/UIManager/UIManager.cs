using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject homePanelUI;
    [SerializeField] GameObject gamePanelUI;
    [SerializeField] GameObject endGamePanelUI;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreTextHome;
    [SerializeField] TextMeshProUGUI highScoreTextEndGame;
    [SerializeField] TextMeshProUGUI differenceToHighScoreText;

    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Update()
    {
        scoreText.text = $"Score: {(int)GameManager.Instance.currentRunTime}";
    }

    public void ActiveHomePanel()
    {
        highScoreTextHome.text = $"Current High Score: {(int)GameManager.Instance.highestRunTime}";

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
        highScoreTextEndGame.text = $"You Lasted\r\n{(int)GameManager.Instance.currentRunTime}\r\nSeconds";

        int difbetweenScores = (int)(GameManager.Instance.highestRunTime - GameManager.Instance.currentRunTime);
        if(difbetweenScores <= 0)
            differenceToHighScoreText.text = $"NEW HIGH SCORE";
        else
            differenceToHighScoreText.text = $"You were {difbetweenScores} Seconds away from a new high score";

        homePanelUI.SetActive(false);
        gamePanelUI.SetActive(false);
        endGamePanelUI.SetActive(true);
    }
}
