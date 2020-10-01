using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Friendly : MonoBehaviour
{
    public GameObject ui_window;
    public AudioSource audioSource;
    public Text textField;
    public string text = "Hi there. Look out for that KOBOLD on the other side!";

    public void Talk()
    {
        ui_window.SetActive(true);
        textField.text = text;
        audioSource.Play();
        
    }
}
