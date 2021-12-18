using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class EventBox : MonoBehaviour
{
    private CharacterManager _playerManager;
    private Action<EventManager.EventInfo> _callBackEvent;
    private UIWalking _uiManager;
    private bool _isBusy = true;
    private int _actionSize;
    private Func<EventManager.EventInfo> _compositeFunc;

    public bool IsBusy => _isBusy;
    public CharacterManager PlayerManager => _playerManager;

    public void Initialize(CharacterManager playerManager, UIWalking uiManager)
    {
        _playerManager = playerManager;
        _uiManager = uiManager;
        _isBusy = false;
    }

    public void SetCompositAction(Func<EventManager.EventInfo> compositeFunc) => _compositeFunc = compositeFunc;

    //���蔲���Ă���ꍇ�Ăяo��
    private void OnTriggerStay(Collider other)
    {
        if (_isBusy == true) return;
        var eventInfo = _compositeFunc();
        _isBusy = true;
        _uiManager.DisplaySelection(eventInfo);
    }

    //���蔲�����u��
    private void OnTriggerExit(Collider other)
    {
        if (_compositeFunc == null) return;

        _uiManager.UnDisplaySelection();
        _isBusy = false;
    }

}
