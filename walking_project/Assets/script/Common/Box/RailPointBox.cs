using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class RailPointBox : MonoBehaviour
{
    [SerializeField] private EventBox m_eventBox = default;
    [SerializeField] private RailManager m_railManager;

    public void Initialize(CharacterManager playerManager, UIManager uiManager)
    {
        m_eventBox.Initialize(playerManager, uiManager);
        m_eventBox.SetCompositAction(CompositeAction);
    }
    
    public void MoveNextRail(int selectedCart)
    {
        var moveAbleRails = m_railManager.GetMoveAbleRails(m_eventBox.PlayerManager);
        m_eventBox.PlayerManager.SetNextRail(moveAbleRails[selectedCart]);
    }
    
    public EventManager.EventInfo CompositeAction()
    {
        var moveAbleRails = m_railManager.GetMoveAbleRails(m_eventBox.PlayerManager);
        EventManager.EventInfo eventInfo = new EventManager.EventInfo();
        eventInfo._selectionCount = moveAbleRails.Count;
        eventInfo._callBackAction = MoveNextRail;

        return eventInfo;
    }


   

}
