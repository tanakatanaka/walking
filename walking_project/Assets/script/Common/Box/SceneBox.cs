using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class SceneBox : MonoBehaviour
{
    [SerializeField] private EventBox _eventBox = default;
    [SerializeField] private string _nextSceneName = default;
    [SerializeField] private List<string> _buttonNameHashList = default;

    public void Initialize(CharacterManager playerManager, UIWalking uiManager)
    {
        _eventBox.Initialize(playerManager, uiManager);
        _eventBox.SetCompositAction(CompositeAction);
    }

    public void SceneEvent(int selected)
    {
        GameManager.Instance.JumpNameScene(_nextSceneName);
    }

    public EventManager.EventInfo CompositeAction()
    {
        EventManager.EventInfo eventInfo = new EventManager.EventInfo();
        eventInfo._selectionCount = 1;
        eventInfo._callBackAction = SceneEvent;
        eventInfo._textHashList = _buttonNameHashList;
        return eventInfo;
    }

}
