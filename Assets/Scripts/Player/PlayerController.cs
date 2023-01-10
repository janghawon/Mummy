using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField] private KeyCode RunKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode JumKey = KeyCode.Space;

    private RotationMouse rotationMouse;
    private PlayerMoveController movement;
    private Status status;
    PlayerWalkSound playerSound;
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rotationMouse = GetComponent<RotationMouse>();
        movement = GetComponent<PlayerMoveController>();
        status = GetComponent<Status>();
        playerSound = GetComponent<PlayerWalkSound>();
    }
    private void Update()
    {
        UpdateRotate();
        UpdateMove();
        UpdateJump();
    }

    private void UpdateJump()
    {
        if(Input.GetKeyDown(JumKey))
        {
            movement.Jump();
        }
    }

    private void UpdateMove()
    {
        float playerX = Input.GetAxisRaw("Horizontal");
        float playerZ = Input.GetAxisRaw("Vertical");

        if(playerX != 0 || playerZ != 0)
        {
            bool isRun = false;
            
            if(playerZ > 0)
            {
                isRun = Input.GetKey(RunKey);
                
            }
            movement.MoveSpeed = isRun == true ? status.RunSpeed : status.WalkSpeed;
            
            if(isRun)
            {
                playerSound.PlaySoundLong(1);
            }
            else if(!isRun)
            {
                playerSound.PlaySoundLong(0);
            }
        }
        else
        {
            movement.MoveSpeed = 0;
            playerSound.EndSound();
        }
        


        movement.MoveTo(new Vector3(playerX, 0, playerZ));
    }

    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationMouse.UpdateRotate(mouseX, mouseY);
    }
    
}
