using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderVolumeMusic : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private string _audioMixerName;

    private Slider _volumeSlider;
    private float value = 20f;
    private float _startVolume = 0.5f;

    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
        _volumeSlider.onValueChanged.AddListener(VolumeChange);
    }

    private void Start()
    {
        _volumeSlider.value = _startVolume;
        VolumeChange(_startVolume);
    }

    private void OnDestroy()
    {
        _volumeSlider.onValueChanged.RemoveAllListeners();
    }

    private void VolumeChange(float volume)
    {
        _audioMixerGroup.audioMixer.SetFloat(_audioMixerName, Mathf.Log10(volume) * value);
    }
}
