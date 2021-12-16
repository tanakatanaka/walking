using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private Button _buttonLeft = default;
    [SerializeField] private Button _buttonRight = default;
    [SerializeField] private Text _Maintext = default;
    private MenuState _menuState = MenuState.NONE;

    public enum MenuState
    {
        NONE = 0,
        SELECTING,
        LODE,
        SAVE,
    };

    public void Initialize()
    {
        //_buttonLeft.
    }

    public void OnCLickLeftButton()
    {

    }

    public void OnCLickRightButton()
    {

    }

}
