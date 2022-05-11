using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource doorClose;
    private AudioSource doorOpen;
    private AudioSource deathEnemy;
    private AudioSource deathBoss;
    private AudioSource shoot;
    private AudioSource hurt;
    public Volumes v;

    private void Awake()
    {
        AudioSource[] audioSources = this.GetComponentsInChildren<AudioSource>();
        doorClose = audioSources[0];
        doorClose.volume = v.volume;
        doorOpen = audioSources[1];
        doorOpen.volume = v.volume;
        deathEnemy = audioSources[2];
        deathEnemy.volume = v.volume;
        deathBoss = audioSources[3];
        deathBoss.volume = v.volume;
        shoot = audioSources[4];
        shoot.volume = v.volume;
        hurt = audioSources[5];
        hurt.volume = v.volume;
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
        if (sound == "deathEnemy")
        {
            deathEnemy.Play();
        }
        if (sound == "deathBoss")
        {
            deathBoss.Play();
        }
        if (sound == "shoot")
        {
            shoot.Play();
        }
        if (sound == "hurt")
        {
            hurt.Play();
        }
    }
}
