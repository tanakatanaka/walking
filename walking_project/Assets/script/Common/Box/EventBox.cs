using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class EventBox : MonoBehaviour
{
    [SerializeField] private List<CinemachineDollyCart> _originCarts;

    private CharacterManager _playerManager;
    private List<CinemachineDollyCart> _ableCarts;
    private Action<EventManager.EventInfo> _callBackEvent;
    private bool _isBusy = true;
    int _actionSize;
    

    public void Initialize(CharacterManager playerManager)
    {
        _playerManager = playerManager;
        _isBusy = false;
    }

    public void SetpCallBackAction(Action<EventManager.EventInfo> callBackEvent)
    {
        _callBackEvent = callBackEvent;
    }

    private void MoveNextRail(int selectedCart)
    {
        _playerManager.SetNextCart(_ableCarts[selectedCart]);
        //_carts[1].transform.SetParent(_playerTransform);
        _isBusy = false;
    }

    //すり抜けている場合呼び出す
    private void OnTriggerStay(Collider other)
    {
        if (_isBusy == true) return;
        _ableCarts = _originCarts.FindAll(c => !_playerManager.IsMyaCart(c));
        EventManager.EventInfo tmp = new EventManager.EventInfo();
        tmp._selectionCount = _ableCarts.Count;
        tmp._callBackAction = MoveNextRail;
        _isBusy = true;
        _callBackEvent(tmp);
    }

    //すり抜けた瞬間
    private void OnTriggerExit(Collider other)
    {
        _isBusy = false;
    }

}
