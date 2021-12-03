using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIDebugController : MonoBehaviour
{
    [SerializeField] private string SceneName = default;

    void Start()
    {
        int a = 0;
    }

    public void OnClickJumpAction()
    {
        GameManager.Instance.I_SceneController.JumpNextScene("Adv");
    }
}
