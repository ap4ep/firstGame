using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            other.GetComponent<IHeal>().TakeHealth(Random.Range(5, 30));
            Destroy(gameObject);
        }
    }
}
