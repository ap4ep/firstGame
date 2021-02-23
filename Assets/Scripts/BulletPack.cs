using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            other.GetComponent<PlayerController>().PlayerHealing(Random.Range(5, 30));
            Destroy(gameObject);
        }
    }
}
