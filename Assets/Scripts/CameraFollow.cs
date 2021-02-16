using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 TargetOffset;

    private void Start()
    {
        TargetOffset = transform.position - Target.position;
    }
    void Update()
    {
        if (Target)
        {
            transform.position = Vector3.Lerp(transform.position, Target.position + TargetOffset, 0.4f);
        }
    }
}
