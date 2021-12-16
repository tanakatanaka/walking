using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuScene : MonoBehaviour
{
    [SerializeField] private List<MenuBox> m_menuBoxes;
    [SerializeField] private BaseScene _baseScene;

    public enum modeSate
    {
        NONE,
        ADV,
        MUSIC_GAME,
        MENU,
        Exit,
    }

    private modeSate m_Mode;

    void Start()
    {
        StartCoroutine(Initialize());
    }

    IEnumerator Initialize()
    {
        _baseScene.Initialize();
        yield return null;
        _baseScene.MenuAction();
        yield return null;
        _baseScene.InitializeCompleteAction();
    }
        

  


    
}
