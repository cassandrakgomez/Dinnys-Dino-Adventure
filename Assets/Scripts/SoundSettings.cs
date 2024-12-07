using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;

    string masterVolume = "MasterVolume";
    string sfxVolume = "SFXVolume";
    string musicVolume = "MusicVolume";

    void Start(){
        masterVolumeSlider.value = PlayerPrefs.GetFloat(masterVolume, 0f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat(sfxVolume, 0f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat(musicVolume, 0f);
        SetMasterVolume();
        SetSFXVolume();
        SetMusicVolume();
    }


   // public void SetMasterVolume(){
   //     audioMixer.SetFloat("MasterVolume", masterVolumeSlider.value);
   //     SetVolume("MasterVolume", masterVolumeSlider.value);
   // }


    public void SetMasterVolume(){
        SetVolume(masterVolume, masterVolumeSlider.value);
        PlayerPrefs.SetFloat(masterVolume, masterVolumeSlider.value);
    }
    public void SetSFXVolume(){
        SetVolume(sfxVolume, sfxVolumeSlider.value);
        PlayerPrefs.SetFloat(sfxVolume, sfxVolumeSlider.value);
    }
    public void SetMusicVolume(){
        SetVolume(musicVolume, musicVolumeSlider.value);
        PlayerPrefs.SetFloat(musicVolume, musicVolumeSlider.value);
    }

    void SetVolume(string groupName, float value){
        float adjustedValue = Mathf.Log10(value) * 20;
        if(value == 0){
            adjustedValue = -80;
        }
        audioMixer.SetFloat(groupName, adjustedValue);
    }
}
