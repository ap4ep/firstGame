using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public event Action OnTrigger = default;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Activator")
            OnTrigger?.Invoke();
    }
}
