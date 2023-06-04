using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Stage", menuName = "TSGameDev/New Game Stage")]
public class GameStageSO : ScriptableObject
{
    public float activationRunTime;
    public float stageObstacleSpeed;
    public float stageMinObstacleSpawnInterval;
    public float stageMaxObstacleSpawnInterval;
}
