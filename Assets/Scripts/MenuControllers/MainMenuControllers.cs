using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllers : MonoBehaviour {
    private const string Name = "MainScene";

    public void StartGame()
    {
        SceneManager.LoadScene(Name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
