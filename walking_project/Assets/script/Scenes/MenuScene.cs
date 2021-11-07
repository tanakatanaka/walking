using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuScene : MonoBehaviour
{
    [SerializeField] private List<MenuBox> m_menuBoxes;

    public enum modeSate
    {
        NONE,
        ADV,
        MUSIC_GAME,
        MENU,
        Exit,
    }

    private modeSate m_Mode;

    //public enum Menu
    void Start()
    {
        m_Mode = modeSate.NONE;
        
        //‘I‘ðƒ{ƒ^ƒ“‚Ì‰Šú‰»
        m_menuBoxes.ForEach(item =>
       {
           item.Initialized(ChangeMode);
        });
    }

    public void ChangeMode(modeSate mode)
    {
        m_Mode = mode;
    }


    
}
