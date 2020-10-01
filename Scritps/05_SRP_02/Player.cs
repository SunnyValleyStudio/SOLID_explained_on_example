using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator playerAnimator;

    public PlayerMovement playerMovement;
    public PlayerRenderer playerRenderer;
    public PlayerAIInteractions playerAiInteractions;

    public GameObject ui_window;

    
    private Vector2 movementVector;

    

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerAiInteractions = GetComponent<PlayerAIInteractions>();


    }
    private void Update()
    {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementVector.Normalize();
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            playerAiInteractions.Interact(playerRenderer.IsSpriteFlipped);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(movementVector);
        if (movementVector.magnitude > 0)
        {
            ui_window.SetActive(false);
        }
        else
        {
            playerAnimator.SetBool("Walk", false);
        }
    }

    

    private void MovePlayer(Vector2 movementVector)
    {
        playerAnimator.SetBool("Walk", true);
        playerMovement.MovePlayer(movementVector);

        playerRenderer.RenderePlayer(movementVector);
    }

    public void ReceiveDamaged()
    {
        playerRenderer.FlashRed();
    }

    
}
