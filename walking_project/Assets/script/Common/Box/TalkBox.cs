using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;
using Fungus;

public class TalkBox : MonoBehaviour
{
    [SerializeField] private EventBox _eventBox = default;
    [SerializeField] private string _message = "";
    private bool _isTalking = false;
    private Flowchart _flowChart;

    public void Initialize(CharacterManager playerManager, UIManager uiManager)
    {
        _eventBox.Initialize(playerManager, uiManager);
        _eventBox.SetCompositAction(CompositeAction);
        _flowChart = GameManager.Instance.I_FlowChart;
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

        return eventInfo;
    }

    IEnumerator Talk()
    {
        if (_isTalking) yield break;

        _isTalking = true;
        //control.enabled = false;
        //player.Stop();
        _flowChart.SendFungusMessage(_message);
        yield return new WaitUntil(() => _flowChart.GetExecutingBlocks().Count == 0);
        _isTalking = false;
        //control.enabled = true;
    }



}
