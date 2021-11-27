using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class CartReceiver : MonoBehaviour
{
    [SerializeField] private RailController m_rail;
    private RadioController m_redioController;
    private bool m_Initialized = false;
    private int m_reverse = 1;

    public RailController MyRail => m_rail;

    public bool IsSameCart(CinemachineDollyCart cartPosition)
    {
        if (cartPosition.gameObject == m_rail.Cart.gameObject) return true;
        return false;
    }

    public void Initialize(RadioController radioController)
    {
        m_redioController = radioController;
        m_redioController.MoveSpeed = m_rail.Cart.m_Speed;

        m_Initialized = true;
    }

    public void SetNextRail(RailController nextRail) => m_rail = nextRail;
   
    public void TurnLookAt()
    {
        //íçéãì_Ç‡âÒì]ÇµÇƒÇ®Ç≠
        Vector3 pos = m_rail.LookAtTransform.localPosition;
        pos.z = -pos.z;
        m_rail.LookAtTransform.transform.localPosition = pos;
        m_redioController.LookAt(m_rail.LookAtTransform);
    }

    public void TurnPlayer()
    {
        Vector3 pos = m_rail.LookAtTransform.localPosition;

        if ((pos.z < 0 && m_reverse > 0) || (pos.z > 0 && m_reverse < 0))
        {
            m_reverse = -m_reverse;
        }
        else if (pos.z < 0 && m_reverse < 0 && !m_rail.IsRailEnd())
        {
            m_redioController.Rotate();
            m_reverse = -m_reverse;
            TurnLookAt();
        }
    }

    public void SitMode()
    {
        m_redioController.Sit();
    }



    // Update is called once per frame
    void Update()
    {
        if (m_Initialized == false) return;

        //transform.position = m_cart.transform.position;

        if (Keyboard.current.nKey.isPressed)
        {
            if (m_redioController._isRotation == false)
            {
                m_redioController.Rotate();
                m_reverse = -m_reverse;
                TurnLookAt();
            }
        }

        if (Keyboard.current.mKey.isPressed)
        {
            m_rail.Cart.m_Speed = 3 * m_reverse;
        }
        else
        {
            m_rail.Cart.m_Speed = 0;
        }

        m_redioController.LookAt(m_rail.LookAtTransform);
        m_redioController.ChangeMoveAnimation(Mathf.Abs(m_rail.Cart.m_Speed) );
    }
}
