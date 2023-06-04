using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    private GameStageSO currentGameStage;
    private Vector3 startingPosition;

    int TERRAIN_MAX_DISTANCE = 10;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        currentGameStage = GameManager.Instance.GetCurrentGameStage();

        float dis = Vector3.Distance(startingPosition, transform.position);
        if (dis >= TERRAIN_MAX_DISTANCE)
            transform.position = startingPosition;
        else
            transform.Translate(currentGameStage.stageObstacleSpeed * Vector3.right * Time.deltaTime);
    }
}
