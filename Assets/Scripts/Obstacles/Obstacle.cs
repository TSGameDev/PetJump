using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed;
    private Transform spawnPoint;

    /// <summary>
    /// Used to setup the obstacle for first time spawning in. Sets spawn point.
    /// </summary>
    public void Initialise(Transform SpawnPoint)
    {
        spawnPoint = SpawnPoint;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Getter for if this obstacle is active in the scene
    /// </summary>
    /// <returns>Bool for if the gameobject is active</returns>
    public bool IsActive() => gameObject.activeInHierarchy;

    /// <summary>
    /// Function used by object pooling to active this object. Moves the object to the spawnpoint and activates it
    /// </summary>
    public void Activate(float speed)
    {
        this.speed = speed;
        transform.position = spawnPoint.transform.position;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Function used by object pooling to deactive this object.
    /// </summary>
    public void Deactive() => gameObject.SetActive(false);

    private void Update()
    {
        ContinousMovement();
    }

    /// <summary>
    /// Function to make the obstacle constantly move left at a defined speed.
    /// </summary>
    private void ContinousMovement()
    {
        float dis = Vector3.Distance(transform.position, spawnPoint.position);
        if(dis >= 11)
        {
            Deactive();
            return;
        }

        transform.Translate(speed * Vector3.right * Time.deltaTime);
    }

}
