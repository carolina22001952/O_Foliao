using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
   [SerializeField] private AudioMixer mixer;
   [SerializeField] private Slider musicSlider, sfxSlider;

    void Start()
    {
        MusicVolume();
        SFXVolume();
    }

    public void MusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("music", Mathf.Log10(volume)*20);
    }

    public void SFXVolume()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("sfx", Mathf.Log10(volume)*20);
    }
}
