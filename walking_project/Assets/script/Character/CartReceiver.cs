using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CartReceiver : MonoBehaviour
{
    [SerializeField] private RailController _rail;
    private RadioController _redioController;
    private bool _Initialized = false;
    private int _reverse = 1;
    private bool _isAbleControll = true;
    private bool _isGo = false;
    private bool _isTurn = false;

    public RailController MyRail => _rail;

    public bool IsSameCart(CinemachineDollyCart cartPosition)
    {
        if (cartPosition.gameObject == _rail.Cart.gameObject) return true;
        return false;
    }

    public void Initialize(RadioController radioController)
    {
        _redioController = radioController;
        _redioController.MoveSpeed = _rail.Cart.m_Speed;

        _Initialized = true;
        if (SceneManager.GetActiveScene().name == "menu") _isAbleControll = false;
    }

    public void SetNextRail(RailController nextRail)
    {
        _rail = nextRail;
        transform.localPosition = new Vector3(0, 0, 0);
    }

    public void TurnCart(bool isReverse)
    {
        if(isReverse)
        {
            _rail.Cart.m_Position = _rail.Cart.m_Path.PathLength;
        }
        else
        {
            _rail.Cart.m_Position = 0;
        }

        ForceTurnLookAt(isReverse);
    }

    private void ForceTurnLookAt(bool isReverse)
    {
        //íçéãì_Ç‡âÒì]ÇµÇƒÇ®Ç≠
        Vector3 pos = _rail.LookAtTransform.localPosition;
     
        if (isReverse)
        {
            pos.z = -Mathf.Abs(pos.z);
        }
        else
        {
            pos.z = Mathf.Abs(pos.z);
        }

        _rail.LookAtTransform.transform.localPosition = pos;
        _redioController.LookAt(_rail.LookAtTransform);
    }

    private void TurnLookAt()
    {
        //íçéãì_Ç‡âÒì]ÇµÇƒÇ®Ç≠
        Vector3 pos = _rail.LookAtTransform.localPosition;
        pos.z = -pos.z;
        _rail.LookAtTransform.transform.localPosition = pos;
        _redioController.LookAt(_rail.LookAtTransform);
    }
    
    public void SetGoMode(bool isGo)
    {
        _isGo = isGo;
    }

    public void SetTurnMode(bool isTurn)
    {
        _isTurn = isTurn;
    }

    public void TurnPlayer()
    {
        Vector3 pos = _rail.LookAtTransform.localPosition;

        if ((pos.z < 0 && _reverse > 0) || (pos.z > 0 && _reverse < 0))
        {
            _reverse = -_reverse;
        }
        else if (pos.z < 0 && _reverse < 0 && !_rail.IsRailEnd())
        {
            _redioController.Rotate();
            _reverse = -_reverse;
            TurnLookAt();
        }
    }

    public bool IsTrueDireciton()
    {
        if (_reverse > 0) return true;
        return false;
    }


    public void SitMode()
    {
        _redioController.Sit();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Initialized == false) return;
        if (_isAbleControll == false) return;

        //transform.position = m_cart.transform.position;

        if (Keyboard.current.nKey.isPressed || _isTurn)
        { 
            if (_redioController._isRotation == false)
            {
                _redioController.Rotate();
                _reverse = -_reverse;
                TurnLookAt();
            }
        }

        if (Keyboard.current.mKey.isPressed || _isGo)
        {
            _rail.Cart.m_Speed = 3 * _reverse;
        }
        else
        {
            _rail.Cart.m_Speed = 0;
        }

        _redioController.LookAt(_rail.LookAtTransform);
        _redioController.ChangeMoveAnimation(Mathf.Abs(_rail.Cart.m_Speed) );
    }
}
