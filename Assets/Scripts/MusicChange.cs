using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public AudioSource calmBGM;
    public AudioSource tenseBGM;
    private bool mute = false;
    private void Start()
    {
        calmBGM.volume = 1;
        if (GameSpeedValue.gameSpeed >= 2)
        {
            calmBGM.Stop();
            tenseBGM.Play();
        }
    }
    void Update()
    {
        if (mute)
        {
            calmBGM.volume -= Time.deltaTime * 0.2f;
            if (calmBGM.volume <= 0)
            {
                mute = false;
                calmBGM.Stop();
                tenseBGM.Play();
            }
        }
    }
    public void ChangeToTenseBGM()
    {
        if (!tenseBGM.isPlaying)
        {
            mute = true;
        }
    }
}
