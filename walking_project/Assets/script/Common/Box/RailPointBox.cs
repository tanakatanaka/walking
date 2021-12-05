using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class RailPointBox : MonoBehaviour
{
    [SerializeField] private EventBox _eventBox = default;
    [SerializeField] private RailManager _railManager;

    public void Initialize(CharacterManager playerManager, UIManager uiManager)
    {
        _eventBox.Initialize(playerManager, uiManager);
        _eventBox.SetCompositAction(CompositeAction);
    }
    
    public void MoveNextRail(int selectedCart)
    {
        var moveAbleRails = _railManager.GetMoveAbleRails(_eventBox.PlayerManager);
        _eventBox.PlayerManager.SetNextRail(moveAbleRails[selectedCart]);
    }
    
    public EventManager.EventInfo CompositeAction()
    {
        var moveAbleRails = _railManager.GetMoveAbleRails(_eventBox.PlayerManager);
        EventManager.EventInfo eventInfo = new EventManager.EventInfo();
        eventInfo._selectionCount = moveAbleRails.Count;
        eventInfo._callBackAction = MoveNextRail;
        eventInfo._textHashList = _railManager.GetRailsHashNameList();
        return eventInfo;
    }


   

}
