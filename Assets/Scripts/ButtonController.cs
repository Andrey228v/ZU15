using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

[RequireComponent(typeof(Button), typeof(AudioSource))]
public class ButtonController : MonoBehaviour, IPointerUpHandler
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Stop();
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        _audioSource.Play();
    }
}
