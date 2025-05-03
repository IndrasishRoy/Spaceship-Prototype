using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _pauseButton;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _startPanel.SetActive(true);
        _pauseButton.SetActive(false);
        _menuPanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        _startPanel.SetActive(false);
        _pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void OnPause()
    {
        Time.timeScale = 0;
        _pauseButton.SetActive(false);
        _menuPanel.SetActive(true);
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        _pauseButton.SetActive(true);
        _menuPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
