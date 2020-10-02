using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class NPC : MonoBehaviour
{
    public UnityEvent<string> OnSpeak;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public virtual void Interact()
    {
        OnSpeak?.Invoke(GetText());
        audioSource.Play();
    }

    protected virtual string GetText()
    {
        return "";
    }


}
