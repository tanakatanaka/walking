using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private List<string> _prevSceneList;
    private GameObject _scenePrefab;

    public void Initialize()
    {
        _prevSceneList = new List<string>();
        var scene = SceneManager.GetActiveScene();
    }

    public void JumpNextScene(string sceneName)
    {
        _prevSceneList.Add(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public bool IsCurrentScene(string sceneName)
    {
        return sceneName == SceneManager.GetActiveScene().name;
    }

    public void LoadScenePrefab(string SceneName)
    {
        var loadPath = "Prefabs/Scenes/";
        _scenePrefab = Instantiate (Resources.Load(loadPath + SceneName) )as GameObject;
        _scenePrefab.transform.SetParent(transform);
    }

    

}
