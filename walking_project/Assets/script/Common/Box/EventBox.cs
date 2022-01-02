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
    private Func<EventManager.EventInfo> _buttonFunc;
    private Func<EventManager.EventInfo> _forceFunc;

    public bool IsBusy => _isBusy;
    public CharacterManager PlayerManager => _playerManager;

    public void Initialize(CharacterManager playerManager, UIWalking uiManager)
    {
        _playerManager = playerManager;
        _uiManager = uiManager;
        _isBusy = false;
    }

    public void SetCompositAction(Func<EventManager.EventInfo> compositeFunc) => _buttonFunc = compositeFunc;
    public void SetFroceAction(Func<EventManager.EventInfo> forceFunc) => _forceFunc = forceFunc;

    private bool IsCorrectDirection(EventManager.Direction direction)
    {
        if (direction == EventManager.Direction.ALL)
        {
            return true;
        }
        else if (direction == EventManager.Direction.NORMAL && _playerManager.IsTrueDirection())
        {
            return true;
        }
        else if (direction == EventManager.Direction.REVERSE && !_playerManager.IsTrueDirection())
        {
            return true;
        }

        return false;
    }



    //すり抜けている場合呼び出す
    private void OnTriggerStay(Collider other)
    {
        if (_isBusy == true) return;
        _isBusy = true;

        if (_forceFunc == null)
        {
            var eventInfo = _buttonFunc();
            if (IsCorrectDirection(eventInfo._direction) == false) return;
            _uiManager.DisplaySelection(eventInfo);
        }
        else
        {
            var eventInfo = _forceFunc();
            if (IsCorrectDirection(eventInfo._direction) == false) return;

            const int forceSelectIndex = 0;
            _forceFunc()._callBackAction(forceSelectIndex);
        }
    }

    //すり抜けた瞬間
    private void OnTriggerExit(Collider other)
    {
        if (_buttonFunc == null) return;

        _uiManager.UnDisplaySelection();
        _isBusy = false;
    }

}
