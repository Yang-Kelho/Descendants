using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Realms.Sync;
using Realms;

public class Player : MonoBehaviour
{
    public PlayerStats playerStats;
    private static long CurrentScore;
    private static long highestScore;
    Realm _realm;
    App realmApp;
    [SerializeField]
    PlayerHealth health;
    public static string userName;

    private void Awake()
    {
        updateHighestScore();
        health = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        var deadCheck = health.IsDead();
        
        realmApp = App.Create("descandants-upzrf");
        if (deadCheck == true)
        {
            if (highestScore < CurrentScore && _realm != null)
            {
                _realm.Write(() =>
                {
                    _realm.Find<PlayerData>(userName).highestScore = highestScore;
                });
            }

            SceneManager.LoadScene("UI");
        }
    }

    public void updateCurrentScore(long score)
    {
        CurrentScore = score;
    }

    public static void increaseCurrentScore(long score)
    {
        CurrentScore += score;
    }

    public async void updateHighestScore()
    {
        var currentUser = realmApp.CurrentUser;
        if (currentUser != null)
        {
            _realm = await Realm.GetInstanceAsync(new PartitionSyncConfiguration("partition", currentUser));
            highestScore = _realm.Find<PlayerData>(userName).highestScore;
        }
        else
            highestScore = 0;

    }

    public static long getCurrentScore()
    {
        return CurrentScore;
    }

    public static long getHighestScore()
    {
        return highestScore;
    }
}
