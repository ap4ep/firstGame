using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _flySpeed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * _flySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            other.GetComponent<IDamageble>().TakeDamage(_damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enviroment")
            Destroy(gameObject);
    }
}
