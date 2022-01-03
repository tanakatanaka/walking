using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GardenScene : MonoBehaviour
{
    [SerializeField] private BaseScene _baseScene = default;
    [SerializeField] RailController _defaultRail = default;
    [SerializeField] List<string> _SceneNameList = default;
    [SerializeField] List<RailController> _railList= default;
    [SerializeField] List<bool> _reverseList = default;

    void Start()
    { 
        _baseScene.Initialize();
        SetPlayerParent();
        StartCoroutine(Initialize());
    }

    public void SetPlayerParent()
    {
        var lastSceneName = GameManager.Instance.I_SceneController.PrevSceneName;
        var tmp = new RailManager.RailListInfo();

        for (int i = 0; i < _SceneNameList.Count; i++)
        {
               if(lastSceneName == _SceneNameList[i])
                {
                    tmp._rail = _railList[i];
                    tmp._isReverse = _reverseList[i];

                    _baseScene.CharacterManager.SetNextRail(tmp);
                    return;
                }
        }

        tmp._rail = _defaultRail;
        tmp._isReverse = false;
        _baseScene.CharacterManager.SetNextRail(tmp);
    }



    IEnumerator Initialize()
    {
        yield return null;
        _baseScene.AdvSetUp();
        yield return null;
        _baseScene.InitializeCompleteAction();
    }
        

  


    
}
