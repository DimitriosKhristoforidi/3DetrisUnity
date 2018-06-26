using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuControllers : MonoBehaviour {
    private const string Name = "MainScene";

    public void StartGame()
    {
        SceneManager.LoadScene(Name);
        AudioListener.pause = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
