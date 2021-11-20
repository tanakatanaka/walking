using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class CartReceiver : MonoBehaviour
{
    [SerializeField] private CinemachineDollyCart _cartPotision;
    private RadioController m_redioController;
    bool m_Initialized = false;
    int reverse = 1;

    public bool IsSameCart(CinemachineDollyCart cartPosition)
    {
        if (cartPosition.gameObject == _cartPotision.gameObject) return true;
        return false;
    }

    public void Initialize(RadioController radioController)
    {
        m_redioController = radioController;
        m_redioController.MoveSpeed = _cartPotision.m_Speed;
        m_Initialized = true;
    }

    public void SetNextCart(CinemachineDollyCart cartPotision) => _cartPotision = cartPotision;

    // Update is called once per frame
    void Update()
    {
        if (m_Initialized == false) return;

        //transform.position = m_cartPotision.transform.position;

        if (Keyboard.current.nKey.isPressed)
        {
            if (m_redioController._isRotation == false)
            {
                m_redioController.Rotate();
                reverse = -reverse;
            }
        }

        if (Keyboard.current.mKey.isPressed)
        {
            _cartPotision.m_Speed = 3 * reverse;
        }
        else
        {
            _cartPotision.m_Speed = 0;
        }

        m_redioController.ChangeMoveAnimation(Mathf.Abs(_cartPotision.m_Speed) );
    }
}
