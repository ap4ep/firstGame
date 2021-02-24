using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _targetOffset;
    [SerializeField][Range(0.1f, 1.0f)] private float _smoothFactor;

    private void Start()
    {
        _targetOffset = transform.position - _target.position;
    }
    void LateUpdate()
    {
        if (_target)
        {
            transform.position = Vector3.Slerp(transform.position, _target.position + _targetOffset, _smoothFactor);
        }
    }
}
