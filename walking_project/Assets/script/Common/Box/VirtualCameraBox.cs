using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public class VirtualCameraBox : MonoBehaviour
{
    [SerializeField] private EventBox _eventBox = default;
    [SerializeField] private GameObject _camera = default;
    private bool _isActiveCamera = false;

    public void Initialize(CharacterManager playerManager, UIWalking uiManager)
    {
        _camera.SetActive(false);
        _eventBox.Initialize(playerManager, uiManager);
        _eventBox.SetFroceAction(CompositeAction);
    }

    public EventManager.EventInfo CompositeAction()
    {
        EventManager.EventInfo eventInfo = new EventManager.EventInfo();
        eventInfo._selectionCount = 1;
        eventInfo._callBackAction = CameraEvent;
        return eventInfo;
    }

    public void CameraEvent(int selected)
    {
        _isActiveCamera = !_isActiveCamera;
        _camera.SetActive(_isActiveCamera);
    }



}
