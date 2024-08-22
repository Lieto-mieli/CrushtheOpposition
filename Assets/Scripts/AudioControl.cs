using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    private float tempnum;
    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume")) {
            audioMixer.SetFloat("MusicVolumeParam", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume")) * 20);
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else { audioMixer.SetFloat("MusicVolumeParam", Mathf.Log10(0.5f) * 20); }
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            audioMixer.SetFloat("SfxVolumeParam", Mathf.Log10(PlayerPrefs.GetFloat("SfxVolume") * 20)); ;
            sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");
        }
        else { audioMixer.SetFloat("SfxVolumeParam", Mathf.Log10(0.5f) * 20); ; }
    }
    public void ChangeMusicVolume()
    {
        tempnum = musicSlider.value;
        audioMixer.SetFloat("MusicVolumeParam", Mathf.Log10(tempnum)*20);
        PlayerPrefs.SetFloat("MusicVolume",tempnum);
    }
    public void ChangeSfxVolume()
    {
        tempnum = sfxSlider.value;
        audioMixer.SetFloat("SfxVolumeParam", Mathf.Log10(tempnum)*20);
        PlayerPrefs.SetFloat("SfxVolume", tempnum);
    }
}
