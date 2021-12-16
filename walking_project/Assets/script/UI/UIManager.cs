using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _cameraController;
    [SerializeField] private GameObject _dashButton;
    [SerializeField] private GameObject _jumpButton;
    [SerializeField] private List<UIController> SelectionButton;
    [SerializeField] private UIActionButton _walkButton;
    [SerializeField] private UIActionButton _TurnButton;
    [SerializeField] private FadeController _fadeController;

    private List<Action> _atctionList;

    public void Initialize(CharacterManager playerManage)
    {
        HideButton();
        _walkButton.Initialize(playerManage.gameObject.GetComponent<CartReceiver>());
        _TurnButton.Initialize(playerManage.gameObject.GetComponent<CartReceiver>());
    }

    public void HideButton()
    {
        SelectionButton.ForEach(b => b?.gameObject.SetActive(false));
    }

    public void HideAll()
    {
        SelectionButton.ForEach(b => b?.gameObject.SetActive(false));
        _dashButton.SetActive(false);
        _jumpButton.SetActive(false);
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

    public void FadeIn()
    {
        _fadeController.StartFadeIn();
    }

    public void FadeOut()
    {
        _fadeController.StartFadeOut();
    }

}
