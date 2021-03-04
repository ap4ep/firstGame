using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapons
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _bulletSpeed = 13;
    [SerializeField] private GameObject _spawnBulletPosition;
    [SerializeField] private GameObject _bullet;

    private PlayerControl _control;

    private void OnEnable()
    {
        _control = GetComponentInParent<PlayerControl>();
        _control.Fired += OnShoot;
    }

    private void OnDisable()
    {
        _control.Fired -= OnShoot;
    }

    public void OnShoot()
    {
        Instantiate(_bullet, _spawnBulletPosition.transform.position, _spawnBulletPosition.transform.rotation)
                .GetComponent<Bullet>().Init(_bulletSpeed, _damage);
    }
}
