using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class RailPointBox : MonoBehaviour
{
    [SerializeField] private EventBox _eventBox = default;
    [SerializeField] private RailManager _railManager;

    public void Initialize(CharacterManager playerManager, UIWalking uiManager)
    {
        _railManager.Initialzie();
        _eventBox.Initialize(playerManager, uiManager);
        _eventBox.SetCompositAction(CompositeAction);
    }
    
    public void MoveNextRail(int selectedCart)
    {
        var moveAbleRails = _railManager.GetMoveAbleRailInfoList(_eventBox.PlayerManager);
        _eventBox.PlayerManager.SetNextRail(moveAbleRails[selectedCart]);
    }
    
    public EventManager.EventInfo CompositeAction()
    {
        var moveAbleRails = _railManager.GetMoveAbleRailInfoList(_eventBox.PlayerManager);
        EventManager.EventInfo eventInfo = new EventManager.EventInfo();
        eventInfo._selectionCount = moveAbleRails.Count;
        eventInfo._callBackAction = MoveNextRail;
        eventInfo._textHashList = _railManager.GetRailsHashNameList(_eventBox.PlayerManager);
        return eventInfo;
    }


   

}
