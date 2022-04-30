using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem{

    public PlayerStats stats;
    public const int MAX_FRAGMENT_NUMBER = 2;
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    private List<Heart> heartList;
    public HealthSystem(int heartAmount, PlayerStats stats)
    {
        this.stats = stats;
        this.heartList = new List<Heart>();
        for (int i = 0; i < heartAmount; i++)
        {
            Heart heart = new Heart(2);
            heartList.Add(heart);
        }

        if (stats.health < stats.maxHealth)
        {
            Damage(stats.maxHealth - stats.health);
        }
        else if (stats.health > stats.maxHealth)
        {
            stats.health = stats.maxHealth;
        }

    }

    public List<Heart> GetHeartList()
    {
        return this.heartList;
    }

    public void Damage(int amount)
    {
        for (int i = heartList.Count - 1; i >= 0; i--)
        {
            Heart heart = heartList[i];
            if (amount > heart.GetFragmentNumber())
            {
                amount -= heart.GetFragmentNumber();
                heart.Damage(heart.GetFragmentNumber());
            }
            else
            {
                heart.Damage(amount);
                break;
            }
        }
        OnDamaged?.Invoke(this, EventArgs.Empty);
    }

    public void Heal(int amount)
    {
        for (int i = 0; i < heartList.Count; i++)
        {
            Heart heart = heartList[i];
            int missingFragments = MAX_FRAGMENT_NUMBER - heart.GetFragmentNumber();
            if (amount > missingFragments)
            {
                heart.Heal(missingFragments);
                amount -= missingFragments;
            }
            else
            {
                heart.Heal(amount);
                break;
            }
        }
        OnHealed?.Invoke(this, EventArgs.Empty);
    }
    public bool IsFullHealth()
    {
        return heartList[heartList.Count-1].GetFragmentNumber() == MAX_FRAGMENT_NUMBER;
    }

    public bool IsDead()
    {
        return heartList[0].GetFragmentNumber() == 0;
    }

    public class Heart
    {
        private int numFragments;
        public Heart(int fragments)
        {
            numFragments = fragments;
        }
        public int GetFragmentNumber()
        {
            return numFragments;
        }

        public void SetFragments(int fragments)
        {
            numFragments = fragments;
        }

        public void Damage(int damageAmount)
        {
            if (damageAmount > numFragments)
            {
                numFragments = 0;
            }
            else
                numFragments -= damageAmount;
        }

        public void Heal(int healAmount)
        {
            if (healAmount > MAX_FRAGMENT_NUMBER - numFragments)
            {
                numFragments = MAX_FRAGMENT_NUMBER;
            }
            else
                numFragments += healAmount;
        }
    }
}
