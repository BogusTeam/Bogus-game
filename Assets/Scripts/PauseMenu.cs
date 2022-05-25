using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuGameObject;
    public bool pauseEnabled;

    // Start is called before the first frame update
    void Start()
    {
        pauseEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuGameObject.SetActive(!pauseEnabled);
            pauseEnabled = !pauseEnabled;
        }
        // Pause all objects!!!
    }

    public void UnpauseGame()
    {
        pauseMenuGameObject.SetActive(false);
        pauseEnabled = false;
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + $"/{Utils.SaveName}"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Utils.LoadSavedGame();
        }
    }

    public void SaveGame()
    {
        var bf = new BinaryFormatter();
        var file = File.Create(Application.persistentDataPath + $"/{Utils.SaveName}");
        bf.Serialize(file, Utils.CreateSaveGameObject(Utils.GetObjectsWithScriptEntity()));
        file.Close();
        Debug.Log("Game Saved");
    }

    public void Quit()
    {
        Application.Quit();
    }
}