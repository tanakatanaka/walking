using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIDebugController : MonoBehaviour
{
    [SerializeField] private string SceneName = default;

    public void OnClickAction()
    {
        GameManager.Instance.I_SceneController.JumpNextScene(SceneName);
    }
}
