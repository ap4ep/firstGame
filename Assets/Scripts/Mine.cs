using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Player")
        {
            other.GetComponent<IDamageble>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
