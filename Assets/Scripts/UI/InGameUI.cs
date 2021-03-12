using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _player;
    private PlayerControl _control;

    void Start()
    {
        _control = _player.GetComponent<PlayerControl>();
        _control.CalledMenu += ShowMenu;
        _canvas.enabled = false;
    }

    private void ShowMenu()
    {
        _canvas.enabled = !_canvas.enabled;
    }
}
