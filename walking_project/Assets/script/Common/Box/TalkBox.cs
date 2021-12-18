using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;
using Fungus;

public class TalkBox : MonoBehaviour
{
    [SerializeField] private EventBox _eventBox = default;
    [SerializeField] private List<string> _buttonNameHashList = default;
    [SerializeField] private string _message = default;
    private bool _isTalking = false;

    public void Initialize(CharacterManager playerManager, UIWalking uiManager)
    {
        _eventBox.Initialize(playerManager, uiManager);
        _eventBox.SetCompositAction(CompositeAction);
    }

    public void TalkEvent(int selected)
    {
        StartCoroutine(Talk());
    }

    public EventManager.EventInfo CompositeAction()
    {
        EventManager.EventInfo eventInfo = new EventManager.EventInfo();
        eventInfo._selectionCount = 1;
        eventInfo._callBackAction = TalkEvent;
        eventInfo._textHashList = _buttonNameHashList;
        return eventInfo;
    }

    IEnumerator Talk()
    {
        if (_isTalking) yield break;

        _isTalking = true;
        //control.enabled = false;
        //player.Stop();
        GameManager.Instance.I_FlowChart.SendFungusMessage(_message);
        yield return new WaitUntil(() => GameManager.Instance.I_FlowChart.GetExecutingBlocks().Count == 0);
        _isTalking = false;
        //control.enabled = true;
    }



}
