using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameOverMenu;

    void Start () {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }
	
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
        FindObjectOfType<AudioController>().Mute();
        gameOverMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

   
}
