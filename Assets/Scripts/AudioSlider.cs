using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    private AudioMixer Mixer;
    private AudioSource AudioSource;
    private TextMeshProUGUI ValueText;
    private AudioMixMode MixMode;

    public void OnChangeSlider(float value)
    {
        ValueText.SetText($"{value.ToString("N4")}");

        switch(MixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                AudioSource.volume = value;
                break;
            case AudioMixMode.LinearMixerVolume:
                Mixer.SetFloat("Volume", (-80 + value * 100));
                break;
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(value) * 20);
                break;
        }
    }

    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }
}
