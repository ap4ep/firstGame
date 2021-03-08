using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _power;

    private void OnTriggerEnter(Collider other)
    {
        var vector = gameObject.transform.position - other.gameObject.transform.position;
        var forceVector = new Vector3(vector.x, 0, vector.z);

        other.GetComponent<Character>().TakeDamage(_damage);
        other.GetComponent<Rigidbody>().AddForce(-forceVector * _power, ForceMode.Impulse);
        Destroy(gameObject, 0.1f);
    }
}
