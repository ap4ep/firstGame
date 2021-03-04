using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _force = 60f;
    [SerializeField] private float _timerCooldown = 2f;
    [SerializeField] private float _explosionRadius;
    
    private float _timer = 0;


    public void Init(Transform spawnPosition)
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(spawnPosition.forward * _force *Time.deltaTime, ForceMode.Impulse);
    }

    private void Update()
    {
        DelayExplosion();
    }

    private void DelayExplosion()
    {
        if ((_timer += Time.deltaTime) > _timerCooldown)
        {
            _timer = 0.0f;
            GrenadeExplosion();
        }
    }

    private void GrenadeExplosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        
        foreach(var hitCollider in hitColliders)
        {
            if(hitCollider.CompareTag("Player") || hitCollider.CompareTag("Enemy"))
            {
                var vector = gameObject.transform.position - hitCollider.gameObject.transform.position;
                var forceVector = new Vector3(vector.x, 0, vector.z);

                hitCollider.GetComponent<Character>().TakeDamage(_damage);
                hitCollider.GetComponent<Rigidbody>().AddForce(-forceVector * 60, ForceMode.Impulse);
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
