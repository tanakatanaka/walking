using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class SofaBox : MonoBehaviour
{
    [SerializeField] private EventBox _eventBox = default;

    public void Initialize(CharacterManager playerManager, UIManager uiManager)
    {
        _eventBox.Initialize(playerManager, uiManager);
    }


}
