using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameOverMenu;
    [SerializeField]
    private Button pauseButton;

    void Start () {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

	void Update()
	{
		if (Input.GetKeyDown("escape"))
			if (pauseMenu.activeSelf == false)
				PauseGame();
			else
				ResumeGame();	}
	
	public void PauseGame() {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
        pauseButton.interactable = false;
		AudioListener.pause = true;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

   
}
