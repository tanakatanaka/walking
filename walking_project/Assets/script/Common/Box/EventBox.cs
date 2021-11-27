using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class EventBox : MonoBehaviour
{
    private CharacterManager m_playerManager;
    private Action<EventManager.EventInfo> _callBackEvent;
    private UIManager _uiManager;
    private bool _isBusy = true;
    private int _actionSize;
    private Func<EventManager.EventInfo> m_compositeFunc;

    public bool IsBusy => _isBusy;
    public CharacterManager PlayerManager => m_playerManager;

    public void Initialize(CharacterManager playerManager, UIManager uiManager)
    {
        m_playerManager = playerManager;
        _uiManager = uiManager;
        _isBusy = false;
    }

    public void SetCompositAction(Func<EventManager.EventInfo> compositeFunc) => m_compositeFunc = compositeFunc;

    //すり抜けている場合呼び出す
    private void OnTriggerStay(Collider other)
    {
        if (_isBusy == true) return;
        var eventInfo = m_compositeFunc();
        _isBusy = true;
        _uiManager.DisplaySelection(eventInfo);
    }

    //すり抜けた瞬間
    private void OnTriggerExit(Collider other)
    {
        _uiManager.UnDisplaySelection();
        _isBusy = false;
    }

}
