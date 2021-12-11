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
        _characterManager.Initialize();
        _eventManager.Initialize(_characterManager);
    }

    
}
