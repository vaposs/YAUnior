using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int _sceneFive = 1;

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartSceneFive()
    {
        SceneManager.LoadScene(_sceneFive);
    }
}