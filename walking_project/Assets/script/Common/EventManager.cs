using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    [SerializeField] private List<RailPointBox> _railPointBoxes = default;
    [SerializeField] private List<SofaBox> _sofaBoxes = default;
    [SerializeField] UIManager _uiManager = default;

    public class EventInfo
    {
        public int _selectionCount = 0;
        public Action<int> _callBackAction = null;
    };

    public void Initialize(CharacterManager playerManage)
    {
        TextManager.Instance.Test();
        _uiManager.Initialize();
        _railPointBoxes.ForEach(e =>
        {
            e?.Initialize(playerManage, _uiManager);
        });

        _sofaBoxes.ForEach(e =>
        {
            e?.Initialize(playerManage, _uiManager);
        });

        _uiManager.gameObject.SetActive(true);
    }

}
