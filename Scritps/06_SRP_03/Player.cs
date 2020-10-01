using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerRenderer playerRenderer;
    public PlayerAIInteractions playerAiInteractions;
    public PlayerInput playerInput;
    public PlayerAnimations playerAnimations;

    public GameObject ui_window;

    private void Start()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerAiInteractions = GetComponent<PlayerAIInteractions>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.OnInteractEvent += () => playerAiInteractions.Interact(playerRenderer.IsSpriteFlipped);

    }

    private void FixedUpdate()
    {
        playerMovement.MovePlayer(playerInput.MovementInputVector);
        playerRenderer.RenderePlayer(playerInput.MovementInputVector);
        playerAnimations.SetupAnimations(playerInput.MovementInputVector);
        
        if (playerInput.MovementInputVector.magnitude > 0)
        {
            ui_window.SetActive(false);
        }
    }

    public void ReceiveDamaged()
    {
        playerRenderer.FlashRed();
    }

    
}
