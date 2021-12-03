using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private List<string> PrevSceneList;

    public void Initialize()
    {
        PrevSceneList = new List<string>();
        var scene = SceneManager.GetActiveScene();
    }

    public void JumpNextScene(string sceneName)
    {
        PrevSceneList.Add(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public bool IsCurrentScene(string sceneName)
    {
        return sceneName == SceneManager.GetActiveScene().name;
    }
}
