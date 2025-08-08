using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{

    public static Scene curr_scene;
    void Start()
    {
        curr_scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + curr_scene.name + "'.");
    }

    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void ExitGame()
    {
        Debug.Log("Exited Game");
        Application.Quit();
    }

    public static void NextScene()
    {
        if (curr_scene.name == "Level 1")
        {
            SceneManager.LoadScene("Level 2");
        }

        if (curr_scene.name == "Level 2")
        {
            SceneManager.LoadScene("Level 3");
        }

        if (curr_scene.name == "Level 3")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
