using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator playerAnimator;
    public SpriteRenderer playerRenderer;

    public Transform raycastPoint;

    public PlayerMovement playerMovement;

    public GameObject ui_window;

    
    private Vector2 movementVector;

    

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        SceneManager.LoadScene("PremadeLevel", LoadSceneMode.Additive);
    }
    private void Update()
    {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementVector.Normalize();
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            Interact();
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

    private void Interact()
    {
        Debug.DrawRay(raycastPoint.position, playerRenderer.flipX ? Vector3.left : Vector3.right, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, playerRenderer.flipX ? Vector3.left : Vector3.right,1);
        if(hit.collider != null)
        {
            if (hit.collider.GetComponent<NPC_Enemy>())
            {
                hit.collider.GetComponent<NPC_Enemy>().GetHit();
            }
            else if (hit.collider.GetComponent<NPC_Friendly>())
            {
                hit.collider.GetComponent<NPC_Friendly>().Talk();
            }
        }

    }

    private void MovePlayer(Vector2 movementVector)
    {
        playerAnimator.SetBool("Walk", true);
        playerMovement.MovePlayer(movementVector);

        if (Mathf.Abs(movementVector.x) > 0.1f)
            playerRenderer.flipX = Vector3.Dot(transform.right, movementVector) < 0;
    }

    public void ReceiveDamaged()
    {
        StopAllCoroutines();
        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        playerRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerRenderer.color = Color.white;
    }
}
