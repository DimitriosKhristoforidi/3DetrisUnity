using UnityEngine;

public class MainMenuControllers : MonoBehaviour {
    private const string Name = "MainScene";

    public void StartGame()
    {
#pragma warning disable CS0618 // Тип или член устарел
        Application.LoadLevel(Name);
#pragma warning restore CS0618 // Тип или член устарел
    }
}
