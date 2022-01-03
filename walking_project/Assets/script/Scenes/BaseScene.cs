using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseScene : MonoBehaviour
{
    [SerializeField] private EventManager _eventManager;
    [SerializeField] private CharacterManager _characterManager;

    public CharacterManager CharacterManager => _characterManager;

    //public enum Menu
    public void Initialize()
    {
        _characterManager.Initialize();
        _eventManager.Initialize(_characterManager);
    }


    //menu�������s���V�[�P���X
    public void MenuSetUp()
    {
        _eventManager.InitializeMenu();
        _characterManager.SitTheSheet();
    }

    public void AdvSetUp()
    {
        _eventManager.InitializeAdv();
    }

    public void InitializeCompleteAction()
    {
        _eventManager.InitializeCompleteAction();
    }


}
