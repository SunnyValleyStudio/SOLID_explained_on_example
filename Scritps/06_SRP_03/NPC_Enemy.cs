using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Enemy : MonoBehaviour
{
    public GameObject ui_window;
    public AudioSource audioSource;
    public Text textField;
    public string text = "I deal 10 physical damage    ( •̀ᴗ•́ )و ̑̑ ";

    public void GetHit()
    {
        ui_window.SetActive(true);
        textField.text = text;
        audioSource.Play();
        FindObjectOfType<Player>().ReceiveDamaged();
    }

}
