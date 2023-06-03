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
    public void Initialise(Transform SpawnPoint, float StartingSpeed)
    {
        spawnPoint = SpawnPoint;
        speed = StartingSpeed;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Function used by object pooling to active this object. Moves the object to the spawnpoint and activates it
    /// </summary>
    public void Activate()
    {
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
    private void ContinousMovement() => transform.Translate(-Vector3.right * speed * Time.deltaTime);

    //Collision detection
    private void OnCollisionEnter(Collision collision)
    {
        string collisionTag = collision.gameObject.tag;
        switch (collisionTag)
        {
            case "Player":
                //endgame
                break;
            case "Deletion":
                Deactive();
                break;
        }
    }
}
