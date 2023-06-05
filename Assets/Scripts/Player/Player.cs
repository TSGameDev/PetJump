using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 jumpForce;

    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded = true;

    private int JUMP_HASH = Animator.StringToHash("Jump");
    private int REVIVAL_HASH = Animator.StringToHash("Revival");
    private int ENDING_1_HASH = Animator.StringToHash("Ending 1");
    private int ENDING_2_HASH = Animator.StringToHash("Ending 2");

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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
            GameManager.Instance.EndGame();
            animator.SetTrigger(ENDING_1_HASH);
        }

        Debug.DrawRay(transform.position + new Vector3(0, 0.1f, 0), -gameObject.transform.up * 0.11f, Color.red);
        if (Physics.Raycast(gameObject.transform.position + new Vector3(0, 0.1f, 0), -gameObject.transform.up, out RaycastHit downHit, 0.11f))
        {
            isGrounded = true;
            if (downHit.collider.CompareTag("Obstacle"))
            {
                GameManager.Instance.EndGame();
                animator.SetTrigger(ENDING_2_HASH);
            }
        }
    }

    public void Jump()
    {
        if(isGrounded)
        {
            rb.AddForce(jumpForce, ForceMode.Impulse);
            animator.SetTrigger(JUMP_HASH);
            isGrounded = false;
        }
    }

    public void Revival()
    {
        animator.SetTrigger(REVIVAL_HASH);
    }
}
