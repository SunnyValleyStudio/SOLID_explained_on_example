using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPC_Friendly : NPC
{
    public string text = "Hi there. Look out for that KOBOLD on the other side!";


    protected override string GetText()
    {
        return text;
    }
}
