using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _flySpeed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * _flySpeed * Time.deltaTime);
    }

    public void Init(int bulletSpeed, int damage)
    {
        _flySpeed = bulletSpeed;
        _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            other.GetComponent<IDamage>().TakeDamage(_damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enviroment")
            Destroy(gameObject);
    }
}
