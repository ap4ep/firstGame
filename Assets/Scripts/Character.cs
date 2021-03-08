using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamage
{
    [SerializeField] protected int _hp;
    protected int _currentHP;

    //public event Action<int> HealthChanged = default;

    private void Awake()
    {
        SetHealth(_hp);
    }

    protected private void SetHealth(int health)
    {
        _currentHP = health;
        //HealthChanged(_currentHP);
    }

    public void TakeDamage(int damage)
    {
        if (_currentHP - damage <= 0)
        {
            _currentHP = 0;
            CharacterDeath();
            //HealthChanged(_currentHP);
        }
        else
        {
            _currentHP -= damage;
            //HealthChanged(_currentHP);
        }  
    }

    public virtual void CharacterDeath()
    {
        Destroy(gameObject);
    }
}
