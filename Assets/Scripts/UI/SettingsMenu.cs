using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;

    private void GetVolume()
    {
        //
    }

    public void SetVolume()
    {
        //
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void GetBack()
    {
        _mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
