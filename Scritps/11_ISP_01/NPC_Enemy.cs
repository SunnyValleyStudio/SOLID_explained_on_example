using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPC_Enemy : NPC, IHittable
{
    
    public string text = "I deal 10 physical damage    ( •̀ᴗ•́ )و ̑̑ ";

    public override void Interact()
    {
        base.Interact();
        FindObjectOfType<Player>().ReceiveDamaged();
    }

    protected override string GetText()
    {
        return text;
    }

    public virtual void GetHit()
    {
        Debug.Log("Ouch!");
    }
}
