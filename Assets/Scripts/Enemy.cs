using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private int _hp = 2;
    
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
