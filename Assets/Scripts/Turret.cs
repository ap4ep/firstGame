using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Character
{
    
    [SerializeField] private float _followDistance = 12f;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private GameObject _spawnBulletPosition;

    private float _time;
    private GameObject _player = null;
    private TurnOnTarget _tracking = null;

    private void Awake()
    {
        _tracking = GetComponent<TurnOnTarget>();
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) < _followDistance)
        {
            _tracking.ObjectRotate(_player);
            if ((_time += Time.deltaTime) > 1.0f)
            {
                _time = 0.0f;
                Attack();
            }
        }
    }

    private void Attack()
    {
        Instantiate(_bullet, _spawnBulletPosition.transform.position, _spawnBulletPosition.transform.rotation);
    }
}
