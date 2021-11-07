using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuBox : MonoBehaviour
{
    [SerializeField] private MenuScene.modeSate m_mode = default;
    private Action<MenuScene.modeSate> m_selectedAction;

    public void Initialized(Action<MenuScene.modeSate> action)
    {
        m_selectedAction = action;
    }


    private void OnTriggerEnter(Collider other)
    {
        m_selectedAction(m_mode);
    }
}
