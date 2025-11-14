using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _targetTeleport;
    private TeleportTrigger _triggerButton;
    private ParticleSystem _particleSystem;
    private bool _isActive = false;
    

    void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _triggerButton = GetComponentInChildren<TeleportTrigger>();
        _particleSystem.Stop();
        _triggerButton.OnTrigger += ActivateTeleport;
    }

    private void TargetTeleport(GameObject gameObject)
    {
        gameObject.transform.position = _targetTeleport.position;
    }

    private void ActivateTeleport()
    {
        _particleSystem.Play();
        _isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActive && other.CompareTag("Player"))
            TargetTeleport(other.gameObject);
    }
}
