using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Score Handler", menuName ="TSGameDev/New Score Handler")]
public class ScoreSO : ScriptableObject
{
    public float currentRunTime = 0;
    public float highestRunTime;

    private void Awake()
    {
        highestRunTime = PlayerPrefs.GetFloat("High Score", 0);
    }

    public void CalculateHighScore()
    {
        if (currentRunTime > highestRunTime)
        {
            highestRunTime = currentRunTime;
            PlayerPrefs.SetFloat("High Score", highestRunTime);
        }
    }
}
