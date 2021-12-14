using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseScene : MonoBehaviour
{
    [SerializeField] private EventManager _eventManager;
    [SerializeField] private CharacterManager _characterManager;

    //public enum Menu
    public void Initialize()
    {
        _eventManager = GameObject.Find("event_manager").GetComponent<EventManager>();
        _characterManager = GameObject.Find("PlayerArmature").GetComponent<CharacterManager>();

        _characterManager.Initialize();
        _eventManager.Initialize(_characterManager);
    }

    
}
