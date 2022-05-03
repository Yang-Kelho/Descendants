using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource doorClose;
    private AudioSource doorOpen;
    private AudioSource deathBoss;

    private void Awake()
    {
        AudioSource[] audioSources = this.GetComponentsInChildren<AudioSource>();
        doorClose = audioSources[0];
        doorOpen = audioSources[1];
        deathBoss = audioSources[2];
    }
    public void PlaySound(string sound)
    {
        if (sound == "doorClose")
        {
            doorClose.Play();
        }
        if (sound == "doorOpen")
        {
            doorOpen.Play();
        }
        if (sound == "deathBoss")
        {
            deathBoss.Play();
        }
    }
}
