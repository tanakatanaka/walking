using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GardenScene : MonoBehaviour
{
    [SerializeField] private BaseScene _baseScene;

    void Start()
    {
        _baseScene.Initialize();
        StartCoroutine(Initialize());
    }

    IEnumerator Initialize()
    {
        yield return null;
        _baseScene.AdvSetUp();
        yield return null;
        _baseScene.InitializeCompleteAction();
    }
        

  


    
}
