using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Volumes", menuName = "VolumesSetting")]
public class Volumes : ScriptableObject
{
    public float volume;

    public void OnVolumeChange(float volume)
    {
        this.volume = volume;
    }
}
