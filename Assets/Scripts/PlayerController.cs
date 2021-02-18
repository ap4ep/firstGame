using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageble
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _rotationSpeed = 30f;
    [SerializeField] private int _hp = 100;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _spawnBulletPosition;
    
    private PlayerInput _input;
    private Vector2 _mousePosition;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Move();
        MouseRotation();
        Shoot();
    }

    private void Shoot()
    {
        if (_input.Player.Shoot.triggered)
            Instantiate(_bullet, _spawnBulletPosition.transform.position, _spawnBulletPosition.transform.rotation);
    }

    private void Move()
    {
        Vector2 direction = _input.Player.Move.ReadValue<Vector2>();
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += moveDirection * scaledMoveSpeed;
    }

    private void MouseRotation()
    {
        transform.rotation = Quaternion.Euler(0f, _input.Player.MousePosition.ReadValue<Vector2>().x / _rotationSpeed, 0f);
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
