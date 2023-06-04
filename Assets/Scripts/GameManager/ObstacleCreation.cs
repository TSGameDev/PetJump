using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreation : MonoBehaviour
{
    [Tooltip("The Amount of instances of each obstacles prefab that should be spawned at the start for object pooling.")]
    [SerializeField] private int numberOfObstaclesInstances = 1;
    [Tooltip("A gameobject to act as the starting point for when obstacles become active")]
    [SerializeField] private Transform obstacleSpawnPoint;
    [Tooltip("A gameobject to store all obstacles under")]
    [SerializeField] private Transform ObjectPoolParent;
    [SerializeField] private List<GameObject> obstaclePrefabs;

    private List<Obstacle> obstacleObjectPool = new List<Obstacle>();
    private float nextObstacleTimer = 1f;

    private GameStageSO CurrentGameStage;

    private void Start()
    {
        ObjectPoolInitialisation();
    }

    private void Update()
    {
        CurrentGameStage = GameManager.Instance.GetCurrentGameStage();

        if(GameManager.Instance.isRunning)
            CalculateNextObstacle();
    }

    private void ObjectPoolInitialisation()
    {
        foreach(GameObject obstaclePrefab in obstaclePrefabs)
        {
            for(int i = 0; i < numberOfObstaclesInstances; i++)
            {
                GameObject NewGameObstacle = Instantiate(obstaclePrefab, obstacleSpawnPoint.position, Quaternion.Euler(270, 90, 0), ObjectPoolParent);
                Obstacle NewObstacle = NewGameObstacle.GetComponent<Obstacle>();
                NewObstacle.Initialise(obstacleSpawnPoint);
                obstacleObjectPool.Add(NewObstacle);
            }
        }
    }

    private void ActiveNextObstacle()
    {
        int NextRandomObstacle = Random.Range(0, obstacleObjectPool.Count);
        if(!obstacleObjectPool[NextRandomObstacle].IsActive())
        {
            obstacleObjectPool[NextRandomObstacle].Activate(CurrentGameStage.stageObstacleSpeed);
        }
        else
            ActiveNextObstacle();
    }

    private void CalculateNextObstacle()
    {
        if(nextObstacleTimer <= 0)
        {
            ActiveNextObstacle();
            float RandomNumber = Random.Range(CurrentGameStage.stageMinObstacleSpawnInterval, CurrentGameStage.stageMaxObstacleSpawnInterval);
            nextObstacleTimer = RandomNumber;
        }
        else
        {
            nextObstacleTimer -= 1 * Time.deltaTime;
        }
    }
}
