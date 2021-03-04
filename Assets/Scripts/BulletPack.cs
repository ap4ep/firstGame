using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            other.GetComponent<Player>().TakeBullet(Random.Range(5, 30));
            Destroy(gameObject);
        }
    }
}
