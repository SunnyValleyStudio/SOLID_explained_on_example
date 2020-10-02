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
    public IMovementInput movementInput;
    public PlayerAnimations playerAnimations;

    public UiController uiController;

    private void Start()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
        playerRenderer = GetComponent<PlayerRenderer>();
        playerAiInteractions = GetComponent<PlayerAIInteractions>();
        movementInput = GetComponent<IMovementInput>();
        movementInput.OnInteractEvent += () => playerAiInteractions.Interact(playerRenderer.IsSpriteFlipped);

    }

    private void FixedUpdate()
    {
        playerMovement.MovePlayer(movementInput.MovementInputVector);
        playerRenderer.RenderePlayer(movementInput.MovementInputVector);
        playerAnimations.SetupAnimations(movementInput.MovementInputVector);
        
        if (movementInput.MovementInputVector.magnitude > 0)
        {
            uiController.ToggleUI(false);
        }
    }

    public void ReceiveDamaged()
    {
        playerRenderer.FlashRed();
    }

    
}
