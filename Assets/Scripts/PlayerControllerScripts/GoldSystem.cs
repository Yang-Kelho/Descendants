using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSystem: MonoBehaviour
{
    private int goldAmount;
    public event EventHandler OnGoldUpdated;
    public PlayerStats stats;

    private void Awake()
    {
        goldAmount = stats.gold;
    }

    public void EarnGold(int amount)
    {
        goldAmount += amount;
        stats.gold = goldAmount;
        OnGoldUpdated?.Invoke(this, EventArgs.Empty);
    }

    public void SpendGold(int amount)
    {
        // pre-condition: current > amount
        if (goldAmount > amount)
        {
            goldAmount -= amount;
            stats.gold = goldAmount;
            OnGoldUpdated?.Invoke(this, EventArgs.Empty);
        }
        else
            Debug.Log("Not enough gold");
    }


    public int GetCurrentGold()
    {
        return goldAmount;
    }
}
