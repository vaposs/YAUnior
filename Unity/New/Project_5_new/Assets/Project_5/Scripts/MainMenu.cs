using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int _taskFive = 1;
    private int _taskSix = 2;

    public void ExitButton()
    {
        Application.Quit();
    }

    public void RunFifthTask()
    {
        SceneManager.LoadScene(_taskFive);
    }

    public void RunSixthTask()
    {
        SceneManager.LoadScene(_taskSix);
    }
}