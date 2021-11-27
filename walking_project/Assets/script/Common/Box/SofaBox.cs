using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class SofaBox : MonoBehaviour
{
    [SerializeField] private EventBox m_eventBox = default;
    [SerializeField] private GameObject m_targetObj = default;

    public void Initialize(CharacterManager playerManager, UIManager uiManager)
    {
        m_eventBox.Initialize(playerManager, uiManager);
        m_eventBox.SetCompositAction(CompositeAction);
    }

    public void SitTheChair(int selected)
    {
        m_eventBox.PlayerManager.SitTheSheet();
    }

    public EventManager.EventInfo CompositeAction()
    {
        EventManager.EventInfo eventInfo = new EventManager.EventInfo();
        eventInfo._selectionCount = 1;
        eventInfo._callBackAction = SitTheChair;

        return eventInfo;
    }


}
