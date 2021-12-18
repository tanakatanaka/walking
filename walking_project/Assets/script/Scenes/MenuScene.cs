using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuScene : MonoBehaviour
{
    [SerializeField] private BaseScene _baseScene;

    public enum modeSate
    {
        NONE,
        ADV,
        MUSIC_GAME,
        MENU,
        Exit,
    }

    private modeSate m_Mode = modeSate.NONE;

    void Start()
    {
        _baseScene.Initialize();
        StartCoroutine(Initialize());
    }

    IEnumerator Initialize()
    {
        yield return null;
        _baseScene.MenuAction();
        yield return null;
        _baseScene.InitializeCompleteAction();
    }
        

  


    
}
