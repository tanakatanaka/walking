using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIController : MonoBehaviour
{
    private Action<int> _atction;
    private int _number;

    public void ResetInfo()
    {
       
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





}
