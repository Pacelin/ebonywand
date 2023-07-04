using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int _gameSceneBuildIndex;

    public void GoToGame()
    {
        SceneManager.LoadScene(_gameSceneBuildIndex, LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
