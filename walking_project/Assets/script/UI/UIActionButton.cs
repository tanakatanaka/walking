using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIActionButton : MonoBehaviour
{
    private bool _isInit = false;
    private bool buttonDownFlag = false;
    private CartReceiver _cartReceiver;
    [SerializeField] private ButtonMode myMode = default;

    enum ButtonMode
    {
        Walk,
        Turn,
    };

    public void Initialize(CartReceiver cartReceiver)
    {
        _cartReceiver = cartReceiver;
        _isInit = true;
    }

    private void Update()
    {
        if (_isInit == false) return;

        if (myMode == ButtonMode.Walk)
        {
            _cartReceiver.SetGoMode(buttonDownFlag);
        }
        else
        {
            _cartReceiver.SetTurnMode(buttonDownFlag);
        }
    }
    
    public void OnButtonDown()
    {
        buttonDownFlag = true;
    }
    
    public void OnButtonUp()
    {
        buttonDownFlag = false;
    }

}
