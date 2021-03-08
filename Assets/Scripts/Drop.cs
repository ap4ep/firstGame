using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private GameObject _grenadeSpawnPoint;
    [SerializeField] private GameObject _grenade;

    private PlayerControl _control;

    private void OnEnable()
    {
        _control = GetComponentInParent<PlayerControl>();
        _control.Droped += OnDrop;
    }

    private void OnDrop()
    {
        var spawn = gameObject.transform.position;
        Instantiate(_grenade, _grenadeSpawnPoint.transform.position, Quaternion.identity).GetComponent<Grenade>().
            Init(gameObject.transform);
    }
}
