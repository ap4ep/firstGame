using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTarget : MonoBehaviour
{
    [SerializeField] private GameObject _turnableObject;
    [SerializeField] private float _rotationSpeed = 6f;

    public void ObjectRotate(GameObject target)
    {
        var direction = target.transform.position - _turnableObject.transform.position;
        var newDirection = Vector3.RotateTowards(_turnableObject.transform.forward, direction, _rotationSpeed * Time.deltaTime, 0f);
        _turnableObject.transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
