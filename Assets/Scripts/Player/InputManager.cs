using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Player player;
    private PlayerControls playerControls;

    private void Awake()
    {
        player = GetComponent<Player>();
        playerControls = new PlayerControls();
    }

    private void Update()
    {
        if(!GameManager.Instance.isRunning)
        {
            playerControls.Disable();
            playerControls.Game.Disable();
        }
        else
        {
            playerControls.Enable();
            playerControls.Game.Enable();
        }
    }

    private void OnEnable()
    {
        playerControls.Game.Jump.performed += ctx => player.Jump();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
