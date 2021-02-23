using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageble
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _rotationSpeed = 30f;
    [SerializeField] private int _hp = 100;
    [SerializeField] private int _bulletCount = 30;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _spawnBulletPosition;
    [SerializeField] private Texture2D _cursor;
    
    private PlayerInput _input;
    private Vector2 _mousePosition;

    private void Awake()
    {
        _input = new PlayerInput();
        Cursor.SetCursor(_cursor, Vector2.zero, CursorMode.Auto);
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
        { 
            Instantiate(_bullet, _spawnBulletPosition.transform.position, _spawnBulletPosition.transform.rotation)
                .GetComponent<Bullet>().Init((int)_moveSpeed + 6);

        }
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
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(_input.Player.MousePosition.ReadValue<Vector2>());
        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    public void PlayerHealing(int healthPower)
    {
        if((healthPower + _hp) <= 100)
            _hp += healthPower;
        if((healthPower + _hp) >= 100)
        {
            healthPower = (healthPower + _hp) - 100;
            _hp += healthPower;
        }
    }

    public void BulletPickup(int bulletCount)
    {
        _bulletCount += bulletCount;
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
