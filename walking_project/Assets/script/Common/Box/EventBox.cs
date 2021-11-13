using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class EventBox : MonoBehaviour
{
    [SerializeField] private List<CinemachineDollyCart> _carts;
    private CharacterManager _playerManager;
    private bool _isInit = false;

    public void Initialize(CharacterManager playerManager)
    {
        _playerManager = playerManager;
        _isInit = true;
    }

    private void MoveNextRail()
    {
        if (_isInit == false) return;
        _playerManager.SetNextCart(_carts[1]);
        //_carts[1].transform.SetParent(_playerTransform);
        _isInit = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        MoveNextRail();
    }
}
