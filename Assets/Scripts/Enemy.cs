using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _trackingDistance = 10f;
    private NavMeshAgent _navMeshAgent;
    private TurnOnTarget _tracking;
    private GameObject _player;
    private int _currentWaypointIndex = 0;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _tracking = GetComponent<TurnOnTarget>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        _navMeshAgent.autoBraking = false;
        _navMeshAgent.SetDestination(_waypoints[0].position);
    }

    private void Update()
    {
        if (CheckDistance())
        {
           _navMeshAgent.stoppingDistance = 3.5f;
            _tracking.ObjectRotate(_player);
            _navMeshAgent.SetDestination(_player.transform.position);
        }    
        else
        {
            _navMeshAgent.stoppingDistance = 0f;
            if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.5f)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                _navMeshAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
            }
        }  
    }

    private bool CheckDistance()
    {
        return Vector3.Distance(_player.transform.position, transform.position) <= _trackingDistance;
    }
}
