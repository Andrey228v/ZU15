using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class ButtonAllVolume : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private Sprite _onTexture;
    [SerializeField] private Sprite _offTexture;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private string _audioMixerName;

    private AudioSource _audioSource;
    private Image _image;
    private float value = 20f;
    private float _minVolume = -80f;
    private float _lastVolume;
    private float _volume;
    private bool _isVolumeOn = true;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _image = GetComponent<Image>();
    }

    private void Start()
    {
         _audioMixerGroup.audioMixer.GetFloat(_audioMixerName, out _volume);
        _lastVolume = _volume;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_isVolumeOn) 
        {
            _image.sprite = _offTexture;
            _audioMixerGroup.audioMixer.GetFloat(_audioMixerName, out _volume);
            _lastVolume = _volume;
            _isVolumeOn = false;
            VolumeChange(_minVolume);
        }
        else
        {
            _image.sprite = _onTexture;
            _isVolumeOn = true;
            VolumeChange(_lastVolume);
        }
    }

    private void VolumeChange(float volume)
    {
        _audioMixerGroup.audioMixer.SetFloat(_audioMixerName, volume);
    }
}
