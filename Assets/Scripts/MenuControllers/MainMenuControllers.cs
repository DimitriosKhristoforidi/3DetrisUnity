using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllers : MonoBehaviour {
    private const string MainScene = "MainScene";
	private const string MuliplayerScene = "MultiplayerScene";

    public void StartGame()
    {
		SceneManager.LoadScene(MainScene);
        AudioListener.pause = false;
    }

	public void StartMultiplayer()
	{
		SceneManager.LoadScene(MuliplayerScene);
		AudioListener.pause = false;
	}

    public void Quit()
    {
        Application.Quit();
    }

}
