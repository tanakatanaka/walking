using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class VirtualCameraBox : MonoBehaviour
{
    [SerializeField] private EventBox _eventBox = default;
    [SerializeField] private GameObject _camera = default;
    [SerializeField] private GameObject _cameraParent = default;
    [SerializeField] private bool _isOnMode = default;
    private bool _isActiveCamera = false;


    public void Initialize(CharacterManager playerManager, UIWalking uiManager)
    {
        if (_camera != null) _camera.SetActive(false);
        _eventBox.Initialize(playerManager, uiManager);
        _eventBox.SetFroceAction(CompositeAction);
    }

    public EventManager.EventInfo CompositeAction()
    {
        EventManager.EventInfo eventInfo = new EventManager.EventInfo();
        eventInfo._selectionCount = 1;
        if (_isOnMode)
        {
            eventInfo._callBackAction = CameraEvent;
        }
        else
        {
            eventInfo._callBackAction = CameraOffEvent;
        }

        return eventInfo;
    }

    public void CameraEvent(int selected)
    {
        foreach (Transform child in _cameraParent.transform)
        {
            child.gameObject.SetActive(false);
        }

        _isActiveCamera = !_isActiveCamera;
        _camera.SetActive(_isActiveCamera);
    }

    public void CameraOffEvent(int selected)
    {
        foreach (Transform child in _cameraParent.transform)
        {
            child.gameObject.SetActive(false);
        }
    }



}
