using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class CartReceiver : MonoBehaviour
{
    [SerializeField] private RailController _rail;
    private RadioController _redioController;
    private bool _Initialized = false;
    private int _reverse = 1;
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
    }

    public void SetNextRail(RailController nextRail) => _rail = nextRail;
   
    public void TurnLookAt()
    {
        //注視点も回転しておく
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

    public void SitMode()
    {
        _redioController.Sit();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Initialized == false) return;

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
