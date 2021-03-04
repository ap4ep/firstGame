using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private GameObject _spawnBulletPosition;

    public void OnShoot()
    {
        Instantiate(_bullet, _spawnBulletPosition.transform.position, _spawnBulletPosition.transform.rotation);
    }
}
