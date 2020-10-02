using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementInput
{
    Vector2 MovementInputVector { get;}
    event Action OnInteractEvent;
}
