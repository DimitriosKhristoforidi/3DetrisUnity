using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllers : MonoBehaviour {
    private const string Name = "MainScene";

    public void StartGame()
    {
        SceneManager.LoadScene(Name);
        FindObjectOfType<AudioController>().Mute();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
