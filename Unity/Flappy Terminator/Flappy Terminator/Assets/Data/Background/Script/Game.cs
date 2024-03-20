using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private PlayerMove _player;
    [SerializeField] private Spawner _spawnerEnemy;
    [SerializeField] private Image _startScreen;

    private int _sceneNumber = 0;

    public event Action PlayGame;

    private void OnEnable()
    {
        _player.RestartGame += GameOver;
    }

    private void OnDisable()
    {
        _player.RestartGame -= GameOver;
    }

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _startScreen.gameObject.active = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}