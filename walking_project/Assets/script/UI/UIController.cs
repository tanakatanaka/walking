using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _text;
    private Action<int> _atction;
    private int _number;
    
    public void ResetInfo()
    {
       
    }

    public void SetButtonText(string textHash)
    {
        _text.text = GameManager.Instance.I_TextManager.GetText(textHash);
    }

    public void SetButtonNumber(int num)
    {
        _number = num;
    }

    public void SetButtonAction(Action<int> action)
    {
        _atction = action;
    }

    public void OnClickAction()
    {
        _atction(_number);
    }

    public void OnClickMove()
    {
        _atction(_number);
    }





}
