using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void Game()
    {
        _button.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
