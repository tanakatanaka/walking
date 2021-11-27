using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class RailPointBox : MonoBehaviour
{
    [SerializeField] private EventBox m_eventBox = default;
    [SerializeField] private List<RailController> m_originCarts;
    private List<RailController> m_ableCarts;

    public void Initialize(CharacterManager playerManager, UIManager uiManager)
    {
        m_eventBox.Initialize(playerManager, uiManager);
        m_eventBox.SetCompositAction(CompositeAction);
    }
    
    public void MoveNextRail(int selectedCart)
    {
        m_eventBox.PlayerManager.SetNextRail(m_ableCarts[selectedCart]);
    }
    
    public EventManager.EventInfo CompositeAction()
    {
        m_ableCarts = m_originCarts.FindAll(c => !m_eventBox.PlayerManager.IsMyaCart(c.Cart));
        EventManager.EventInfo eventInfo = new EventManager.EventInfo();
        eventInfo._selectionCount = m_ableCarts.Count;
        eventInfo._callBackAction = MoveNextRail;

        return eventInfo;
    }


   

}
