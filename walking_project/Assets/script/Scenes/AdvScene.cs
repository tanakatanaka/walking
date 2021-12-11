using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdvScene : MonoBehaviour
{
    [SerializeField] private BaseScene _baseScene;
   
    void Start()
    {
        _baseScene.Initialize();
    }

    
}
