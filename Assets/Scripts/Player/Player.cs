using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        ForwardCheck();
    }

    private void ForwardCheck()
    {
        Debug.DrawRay(transform.position + new Vector3(0, 0.1f, 0), gameObject.transform.forward * 0.25f, Color.red);
        if (Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), gameObject.transform.forward, out RaycastHit frontHit, 0.25f))
        {
            //if hits anything, end game
        }
    }

    private void Jump()
    {
        Debug.DrawRay(transform.position + new Vector3(0, 0.1f, 0), -gameObject.transform.up * 0.25f, Color.red);
        if (Physics.Raycast(gameObject.transform.position + new Vector3(0, 0.1f, 0), -gameObject.transform.up, out RaycastHit downHit, 0.25f))
        {
            //If hits floor, put character to it
            //if hits anything else, end game.
        }
    }

}
