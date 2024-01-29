using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int _startGameScene = 1;

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartButton()
    {
        SceneManager.LoadScene(_startGameScene);
    }
}
