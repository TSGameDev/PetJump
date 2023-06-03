using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 jumpForce = Vector3.zero;

    private Rigidbody rb;

    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CollisionChecks();
    }

    private void CollisionChecks()
    {
        Debug.DrawRay(transform.position + new Vector3(0, 0.1f, 0), gameObject.transform.forward * 0.25f, Color.red);
        if (Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), gameObject.transform.forward, out RaycastHit frontHit, 0.25f))
        {
            //if hits anything, end game
        }

        Debug.DrawRay(transform.position + new Vector3(0, 0.1f, 0), -gameObject.transform.up * 0.11f, Color.red);
        if (Physics.Raycast(gameObject.transform.position + new Vector3(0, 0.1f, 0), -gameObject.transform.up, out RaycastHit downHit, 0.11f))
        {
            isGrounded = true;
            if (downHit.collider.CompareTag("Obstacle"))
            {
                //end game
            }
        }
    }

    public void Jump()
    {
        if(isGrounded)
        {
            rb.AddForce(jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

}
