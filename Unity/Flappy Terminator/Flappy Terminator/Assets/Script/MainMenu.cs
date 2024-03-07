using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        Stop();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _mainPanel.active = true;
            Stop();
        }
    }

    private void Stop()
    {
        Time.timeScale = 0;
    }

    private void Play()
    {
        Time.timeScale = 1;
    }

    public void StartButton()
    {
        _mainPanel.active = false;
        Play();
    }

    public void ExittButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void GameOver()
    {
        _gameOverPanel.active = true;
    }
}