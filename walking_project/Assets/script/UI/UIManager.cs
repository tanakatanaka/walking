using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _cameraController;
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
        DisplayButton(eventInfo._selectionCount);

        SelectionButton.ForEach(b =>
        {
            if (b.gameObject.activeSelf)
            {
                b?.SetButtonNumber(i);
                b?.SetButtonText(eventInfo._textHashList[i]);
                b?.SetButtonAction(eventInfo._callBackAction);
                i++;
                if (i >= eventInfo._selectionCount) return;
            }
        }
        );
    }

    private void DisplayButton(int buttonCount)
    {
        if(buttonCount == 1)
        {
            SelectionButton[0].gameObject.SetActive(false);
            SelectionButton[1].gameObject.SetActive(true);
            SelectionButton[2].gameObject.SetActive(false);
        }
        else if (buttonCount == 2)
        {
            SelectionButton[0].gameObject.SetActive(true);
            SelectionButton[1].gameObject.SetActive(false);
            SelectionButton[2].gameObject.SetActive(true);
        }
        else if (buttonCount == 3)
        {
            SelectionButton[0].gameObject.SetActive(true);
            SelectionButton[1].gameObject.SetActive(true);
            SelectionButton[2].gameObject.SetActive(true);
        }
    }


    public void UnDisplaySelection()
    {
        SelectionButton.ForEach(b => b?.gameObject.SetActive(false));
    }

}
