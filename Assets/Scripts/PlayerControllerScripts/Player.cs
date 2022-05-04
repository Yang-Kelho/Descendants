using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Realms.Sync;
using Realms;

public class Player : MonoBehaviour
{
    public PlayerStats playerStats;
    public long CurrentScore;
    public void UpdateCurrentScore(long score)
    {
        CurrentScore = score;
    }

    public void IncreaseCurrentScore(long score)
    {
        CurrentScore += score;
    }

}
