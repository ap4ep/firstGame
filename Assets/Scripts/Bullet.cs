using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _flySpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * _flySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision == GetComponent<IDamageble>())
        {
            collision.gameObject.GetComponent<IDamageble>().TakeDamage(_damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
