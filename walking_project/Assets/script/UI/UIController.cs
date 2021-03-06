using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _text;
    private Action<int> _atction;
    private Action _hideButtonAtction;
    private int _number;
    
    public void SetText(string textHash)
    {
        _text.text = GameManager.Instance.I_TextManager.GetText(textHash);
    }

    public void SetButtonNumber(int num)
    {
        _number = num;
    }

    public void SetButtonAction(Action<int> action, Action hideAction)
    {
        _atction = action;
        _hideButtonAtction = hideAction;
    }

    public void OnClickAction()
    {
        _atction(_number);
        if (_hideButtonAtction != null) _hideButtonAtction();

    }

    public void OnClickMove()
    {
        _atction(_number);
    }





}
