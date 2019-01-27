using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;


public class Scene
{
    public bool solved;
    public string sceneName;

    public Scene (bool s, string n)
    {
        solved = s;
        sceneName = n;
    }

    public void solve()
    {
        solved = true;
    }
}

public class LevelLoader : MonoBehaviour
{
    List<Scene> scenes;
    private int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        scenes = new List<Scene>() { new Scene(false, "Day0Dream"), new Scene(false, "Day1"), new Scene(false, "Day1Dream"), new Scene(false, "Day2"), new Scene (false, "Day2Dream"), new Scene (false, "Day3") };
        currentSceneIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Determines what scene needs to be switched to at this time and loads that one.
    /// </summary>
    public void TransisitionScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Day0Dream":
                //load Day1
                SceneManager.LoadScene("Day1");
                Camera.main.GetComponent<PostProcessingBehaviour>().enabled = false;
                currentSceneIndex = 1;
                break;
            case "Day1":
                if (scenes[1].solved)
                {
                    SceneManager.LoadScene("Day1Dream");
                    currentSceneIndex = 2;
                    Camera.main.GetComponent<PostProcessingBehaviour>().enabled = true;
                }
                else
                {
                    SceneManager.LoadScene("Day0Dream");
                    currentSceneIndex = 0;
                    Camera.main.GetComponent<PostProcessingBehaviour>().enabled = true;
                }
                break;
            case "Day1Dream":
                SceneManager.LoadScene("Day2");
                currentSceneIndex = 3;
                break;
            case "Day2":
                if (scenes[3].solved)
                {
                    SceneManager.LoadScene("Day2Dream");
                    currentSceneIndex = 4;
                }
                else
                {
                    SceneManager.LoadScene("Day1Dream");
                    currentSceneIndex = 2;
                }
                break;
            case "Day2Dream":
                SceneManager.LoadScene("Day3");
                currentSceneIndex = 5;
                break;
            case "Day3":
                SceneManager.LoadScene("CreditScene");
                break;
        }
    }

    public void CompleteLevel()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Day0Dream":
                currentSceneIndex = 0;
                break;
            case "Day1":
                currentSceneIndex = 1;
                break;
            case "Day1Dream":
                
                currentSceneIndex = 2;
                break;
            case "Day2":
                currentSceneIndex = 3;
                break;
            case "Day2Dream":
                currentSceneIndex = 4;
                break;
            case "Day3":
                currentSceneIndex = 5;
                break;
        }

        scenes[currentSceneIndex].solve();
    }
}
