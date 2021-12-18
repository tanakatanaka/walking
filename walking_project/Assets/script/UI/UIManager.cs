using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIMenu _originUiMenu = default;
    [SerializeField] public UIWalking _originUiWalking = default;
    [SerializeField] private FadeController _fadeController;

    private UIMenu _uiMenu = null;
    private UIWalking _uiWalking = null;
    private CharacterManager _playerManage;

    public UIWalking GetUIWalking()
    {
        if (_uiWalking == null) SetUpUIWalking();
        return _uiWalking;
    }


    public void Initialize(CharacterManager playerManage)
    {
        _playerManage = playerManage;
    }

    private void SetUpUIMenu()
    {
        _uiWalking = Instantiate(_originUiWalking, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        _uiWalking.Initialize(_playerManage);
        _uiWalking.transform.SetParent(transform);
    }

    public void SetUpUIWalking()
    {
        _uiWalking = Instantiate(_originUiWalking, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        _uiWalking.Initialize(_playerManage);
        _uiWalking.transform.SetParent(transform);
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
