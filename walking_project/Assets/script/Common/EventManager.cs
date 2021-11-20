using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    [SerializeField] private RailManager _railManager;
    [SerializeField] private List<EventBox> _eventBoxes = default;
    [SerializeField] UIManager _uiManager = default;

    public class EventInfo
    {
        public int _selectionCount = 0;
        public Action<int> _callBackAction = null;
    };

    public void Initialize(CharacterManager playerManage)
    {
        _eventBoxes.ForEach(e =>
        {
            e?.Initialize(playerManage);
            e?.SetpCallBackAction(EventAction);
        });
        _uiManager.Initialize();
        _uiManager.gameObject.SetActive(true);
    }
    
    public void EventAction(EventInfo eventIfno)
    {
        //eventIfno‚ð‚à‚Æ‚ÉUI‚ð•\Ž¦‚·‚é
        _uiManager.DisplaySelection(eventIfno);
    }


   

}
