using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject ObjectForSpawn;
    private Vector3 _parentPosition;

    void Start()
    {
        _parentPosition = transform.position;
        Instantiate(ObjectForSpawn, _parentPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
