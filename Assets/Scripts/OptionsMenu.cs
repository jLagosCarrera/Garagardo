using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject musicSlider, soundSlider;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.GetFloat("musicVolume", out float musicVolume);
        audioMixer.GetFloat("soundVolume", out float soundVolume);
        musicSlider.GetComponent<Slider>().value = musicVolume;
        soundSlider.GetComponent<Slider>().value = soundVolume;
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }
    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("soundVolume", volume);
    }
}
