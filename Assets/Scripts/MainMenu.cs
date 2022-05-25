using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        // Application.LoadLevel("MainScene");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + $"/{Utils.SaveName}"))
        {
            SceneManager.LoadScene("MainScene");
            Utils.LoadSavedGame();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}