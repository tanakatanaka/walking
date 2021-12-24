using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private UIController _LeftText = default;
    [SerializeField] private UIController _RightText = default;
    [SerializeField] private UIController _Maintext = default;
    private MenuState _menuState = MenuState.NONE;

    public enum MenuState
    {
        NONE = 0,
        START,
        LOAD,
        SAVE,
    };

    public void Initialize(MenuState menuState = MenuState.NONE)
    {
        if(menuState == MenuState.SAVE)
        {
            _menuState = MenuState.SAVE;
            GameManager.Instance.I_gameInfo.ChangeMode(GameInfo.GamePlayData.Mode.MENU);
            return;
        }
        

        _LeftText.SetText("menu_Start");
        _RightText.SetText("menu_Load");
        _Maintext.SetText("menu_Title");
    }

    public void OnCLickLeftButton()
    {
        _menuState = MenuState.START;
        GameManager.Instance.I_gameInfo.ChangeMode(GameInfo.GamePlayData.Mode.INGAME);
    }

    public void OnCLickRightButton()
    {
        _menuState = MenuState.LOAD;
        GameManager.Instance.I_gameInfo.ChangeMode(GameInfo.GamePlayData.Mode.LOAD);
    }

}
