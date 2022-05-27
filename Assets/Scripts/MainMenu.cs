using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("test_location_2");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + $"/{Utils.SaveName}"))
        {
            SceneManager.LoadScene("test_location_2");
            SceneManager.sceneLoaded += (_, _) => Utils.LoadSavedGame();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}