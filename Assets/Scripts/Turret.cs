using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject _tower;
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private GameObject _spawnBulletPosition;

    private float _time;
    private GameObject _player = null;
    private bool _inRange = false;
    
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (_inRange)
        {
            FollowPlayer(_player);
            if ((_time += Time.deltaTime) > 1.0f)
            {
                    _time = 0.0f;
                    Attack();
            }
        }
    }

    private void FollowPlayer(GameObject player)
    {
        var direction = player.transform.position - _tower.transform.position;
        var newDirection = Vector3.RotateTowards(_tower.transform.forward, direction, _rotationSpeed * Time.deltaTime, 0f);
        _tower.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void Attack()
    {
        Instantiate(_bullet, _spawnBulletPosition.transform.position, _spawnBulletPosition.transform.rotation);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        { 
            _inRange = false;
        }
    }
}
