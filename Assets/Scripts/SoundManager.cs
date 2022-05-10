using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource doorClose;
    private AudioSource doorOpen;
    private AudioSource deathBoss;
    public Volumes v;

    private void Awake()
    {
        AudioSource[] audioSources = this.GetComponentsInChildren<AudioSource>();
        doorClose = audioSources[0];
        doorClose.volume = v.volume;
        doorOpen = audioSources[1];
        doorOpen.volume = v.volume;
        deathBoss = audioSources[2];
        deathBoss.volume = v.volume;
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
