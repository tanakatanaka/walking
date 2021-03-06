using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class SofaBox : MonoBehaviour
{
    [SerializeField] private EventBox _eventBox = default;
    [SerializeField] private List<string> _buttonNameHashList = default;
    [SerializeField] private GameObject _targetObj = default;

    public void Initialize(CharacterManager playerManager, UIWalking uiManager)
    {
        _eventBox.Initialize(playerManager, uiManager);
        _eventBox.SetCompositAction(CompositeAction);
    }

    public void SaveData(int selected)
    {
        GameManager.Instance.SaveData();
    }

    public EventManager.EventInfo CompositeAction()
    {
        EventManager.EventInfo eventInfo = new EventManager.EventInfo();
        eventInfo._selectionCount = 1;
        eventInfo._callBackAction = SaveData;
        eventInfo._textHashList = _buttonNameHashList;
        return eventInfo;
    }


}
