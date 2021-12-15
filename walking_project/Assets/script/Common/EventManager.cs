using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    [SerializeField] private List<RailPointBox> _railPointBoxes = default;
    [SerializeField] private List<SofaBox> _sofaBoxes = default;
    [SerializeField] private List<TalkBox> _talkBoxes = default;
    private UIManager _uiManager;

    public class EventInfo
    {
        public int _selectionCount = 0;
        public Action<int> _callBackAction = null;
        public List<string> _textHashList = new List<string>();
    };

    public void Initialize(CharacterManager playerManage)
    {
        _uiManager = GameObject.Find("UI_Canvas_Walking").GetComponent<UIManager>();

        _uiManager.Initialize(playerManage);
        _railPointBoxes.ForEach(e =>
        {
            e?.Initialize(playerManage, _uiManager);
        });

        _sofaBoxes.ForEach(e =>
        {
            e?.Initialize(playerManage, _uiManager);
        });

        _talkBoxes.ForEach(e =>
        {
            e?.Initialize(playerManage, _uiManager);
        });

        _uiManager.gameObject.SetActive(true);
        _uiManager.FadeIn();
    }

}
