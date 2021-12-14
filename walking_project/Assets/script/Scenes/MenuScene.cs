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
        _baseScene.Initialize();
    }

    public void ChangeMode(modeSate mode)
    {
        m_Mode = mode;
    }


    
}
