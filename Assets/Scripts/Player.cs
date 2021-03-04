using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IHeal
{
    [SerializeField] private int _bulletCount = 100;

    public void TakeBullet(int bulletCount)
    {
        _bulletCount += bulletCount;
    }

    public void TakeHealth(int health)
    {
        if (health + _currentHP <= 100)
        {
            _currentHP += health;
            //HealthChanged(_currentHP);
        }

        if (health + _currentHP >= 100)
        {
            _currentHP = _hp;
            //HealthChanged(_currentHP);
        }
    }
}
