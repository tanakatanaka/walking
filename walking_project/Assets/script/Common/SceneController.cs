using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _sceneParent = default;
    private string _prevSceneName = "";

    public string PrevSceneName => _prevSceneName;

    public void Initialize()
    {
        var scene = SceneManager.GetActiveScene();
    }

    public void JumpNextScene(string sceneName)
    {
        _prevSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public bool IsCurrentScene(string sceneName)
    {
        return sceneName == SceneManager.GetActiveScene().name;
    }

    public void LoadScenePrefab(string SceneName)
    {
        var objName = SceneName + "_scene_obj";
        var target = GameObject.Find(objName);

        var loadPath = "Prefabs/SceneObj/" + objName;
        if (target != null) return;

        var  scneObj = Instantiate (Resources.Load(loadPath) )as GameObject;
        scneObj.transform.SetParent(_sceneParent.transform);
    }

    

}
