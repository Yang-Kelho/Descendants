using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSystem
{
    private int goldAmount;
    public event EventHandler OnGoldUpdated;

    public GoldSystem()
    {
        goldAmount = 0;
    }

    public void EarnGold(int amount)
    {
        goldAmount += amount;
        OnGoldUpdated?.Invoke(this, EventArgs.Empty);
    }

    public void SpendGold(int amount)
    {
        // pre-condition: current > amount
        goldAmount -= amount;
        OnGoldUpdated?.Invoke(this, EventArgs.Empty);
    }

    public int GetCurrentGold()
    {
        return goldAmount;
    }
}
