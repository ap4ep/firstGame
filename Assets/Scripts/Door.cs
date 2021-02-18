using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            gameObject.SetActive(false);
    }
}