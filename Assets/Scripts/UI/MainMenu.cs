using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _settings;

    private void Start()
    {
        _settings.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowSettings()
    {
        gameObject.SetActive(false);
        _settings.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
