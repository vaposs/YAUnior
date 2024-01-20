using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _infoText;

    private int _startGameScene = 1;

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartButton()
    {
        SceneManager.LoadScene(_startGameScene);
    }

    public void MenuButton()
    {
        _menu.active = true;
    }

    public void ReturnMenuButton()
    {
        _menu.active = false;
    }

    public void ShowInfo()
    {
        if(_infoText.active)
        {
            _infoText.active = false;
        }
        else
        {
            _infoText.active = true;
        }
    }
}