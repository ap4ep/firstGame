using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
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
