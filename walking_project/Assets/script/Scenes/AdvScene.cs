using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdvScene : MonoBehaviour
{
    [SerializeField] private EventManager _eventManager;
    [SerializeField] private CharacterManager _characterManager;

    //public enum Menu
    void Start()
    {
        _characterManager.Initialize();
        _eventManager.Initialize(_characterManager);
    }

    
}
