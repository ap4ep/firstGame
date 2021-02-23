using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject _door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            _door.SetActive(false);
    }
}
