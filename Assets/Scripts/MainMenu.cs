using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + $"/{Utils.SaveName}"))
        {
            SceneManager.LoadScene("MainScene");
            SceneManager.sceneLoaded += (_, _) => Utils.LoadSavedGame();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}