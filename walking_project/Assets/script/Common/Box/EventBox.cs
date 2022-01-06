using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class EventBox : MonoBehaviour
{
    [SerializeField] private Direction _direction = default;
    [SerializeField] private bool _isSelectAndOut = false;

    private CharacterManager _playerManager;
    private Action<EventManager.EventInfo> _callBackEvent;
    private UIWalking _uiManager;
    private bool _isBusy = true;
    private int _actionSize;
    private Func<EventManager.EventInfo> _buttonFunc;
    private Func<EventManager.EventInfo> _forceFunc;

    public bool IsBusy => _isBusy;
    public CharacterManager PlayerManager => _playerManager;

    public enum Direction
    {
        ALL,
        NORMAL,
        REVERSE,
    };

    public void Initialize(CharacterManager playerManager, UIWalking uiManager)
    {
        _playerManager = playerManager;
        _uiManager = uiManager;
        _isBusy = false;
    }

    public void SetCompositAction(Func<EventManager.EventInfo> compositeFunc) => _buttonFunc = compositeFunc;
    public void SetFroceAction(Func<EventManager.EventInfo> forceFunc) => _forceFunc = forceFunc;

    private bool IsCorrectDirection()
    {
        if (_direction == Direction.ALL) return true;
        else if (_direction == Direction.NORMAL && _playerManager.IsTrueDirection()) return true;
        else if (_direction == Direction.REVERSE && !_playerManager.IsTrueDirection()) return true;

        return false;
    }

    //Ç∑ÇËî≤ÇØÇƒÇ¢ÇÈèÍçáåƒÇ—èoÇ∑
    private void OnTriggerStay(Collider other)
    {
        if (_isBusy == true) return;
        _isBusy = true;

        if (_forceFunc == null)
        {
            var eventInfo = _buttonFunc();
            if (IsCorrectDirection() == false) return;
            _uiManager.DisplaySelection(eventInfo, _isSelectAndOut);
        }
        else
        {
            var eventInfo = _forceFunc();
            if (IsCorrectDirection() == false) return;

            const int forceSelectIndex = 0;
            _forceFunc()._callBackAction(forceSelectIndex);
        }
    }

    //Ç∑ÇËî≤ÇØÇΩèuä‘
    private void OnTriggerExit(Collider other)
    {
        _uiManager.UnDisplaySelection();
        _isBusy = false;
    }

}
