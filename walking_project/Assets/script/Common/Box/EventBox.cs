using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class EventBox : MonoBehaviour
{
    private CharacterManager _playerManager;
    //railØ‚è‘Ö‚¦ƒCƒxƒ“ƒg‚É‚Â‚¢‚Ä
    [SerializeField] private List<CinemachineDollyCart> _carts;
    private bool _isInit = false;
    int _actionSize;
    private Action<EventManager.EventInfo> _callBackEvent;

    public void Initialize(CharacterManager playerManager)
    {
        _playerManager = playerManager;
        _isInit = true;
    }

    public void SetpCallBackAction(Action<EventManager.EventInfo> callBackEvent)
    {
        _callBackEvent = callBackEvent;
    }

    private void MoveNextRail(int selectedCart)
    {
        _playerManager.SetNextCart(_carts[selectedCart]);
        //_carts[1].transform.SetParent(_playerTransform);
        _isInit = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (_isInit == false) return;
        EventManager.EventInfo tmp = new EventManager.EventInfo();
        tmp._selectionCount = _carts.Count;
        tmp._callBackAction = MoveNextRail;

        _callBackEvent(tmp);
    }
}
