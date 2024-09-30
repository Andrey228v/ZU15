using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class SoundReproductionElement : MonoBehaviour, IPointerUpHandler
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
