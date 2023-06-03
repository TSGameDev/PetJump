using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreation : MonoBehaviour
{
    [Tooltip("The Amount of instances of each obstacles prefab that should be spawned at the start for object pooling. If there isn't enough obstacles more will be spawned as required")]
    [SerializeField] private int numberOfObstaclesInstances = 1;
    [Tooltip("A gameobject to act as the starting point for when obstacles become active")]
    [SerializeField] private Transform obstacleSpawnPoint;
    [Tooltip("A gameobject to store all obstacles under")]
    [SerializeField] private Transform ObjectPoolParent;
    [SerializeField] private List<GameObject> obstaclePrefabs;

    [SerializeField] private float objectSpeed = 2f;
    private Queue<GameObject> obstacleObjectPool = new Queue<GameObject>();

    private void Start()
    {
        ObjectPoolInitialisation();
    }

    private void ObjectPoolInitialisation()
    {
        foreach(GameObject obstaclePrefab in obstaclePrefabs)
        {
            for(int i = 0; i == numberOfObstaclesInstances; i++)
            {
                GameObject NewObstacle = Instantiate(obstaclePrefab, obstacleSpawnPoint.position, Quaternion.identity, ObjectPoolParent);
                obstacleObjectPool.Enqueue(NewObstacle);
                NewObstacle.GetComponent<Obstacle>().Initialise(obstacleSpawnPoint, objectSpeed);
            }
        }
    }
}
