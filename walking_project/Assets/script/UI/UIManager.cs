using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField]GameObject _cameraController;
    [SerializeField] GameObject _dashButton;
    [SerializeField] GameObject _jumpButton;
    [SerializeField] List<UIController> SelectionButton;
    private List<Action> _atctionList;

    public void Initialize()
    {
        HideBUtton();
    }

    public void HideBUtton()
    {
        SelectionButton.ForEach(b => b?.gameObject.SetActive(false));
    }

    public void DisplaySelection(EventManager.EventInfo eventInfo)
    {
        int i = 0;
        SelectionButton.ForEach(b =>
        {
            b?.gameObject.SetActive(true);
            b?.SetButtonNumber(i);
            b?.SetButtonAction(eventInfo._callBackAction);
            i++;
            if (i >= eventInfo._selectionCount) return;
        }
        );
    }


}
