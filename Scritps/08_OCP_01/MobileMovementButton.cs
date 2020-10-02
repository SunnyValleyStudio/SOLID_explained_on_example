using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileMovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayermobileInput input;
    public Vector2 movementDirection;
    public void OnPointerDown(PointerEventData eventData)
    {
        input.GetMovementinput(movementDirection);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input.ResetInput();
    }
}
