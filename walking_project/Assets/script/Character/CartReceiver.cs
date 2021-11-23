using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class CartReceiver : MonoBehaviour
{
    [SerializeField] private CinemachineDollyCart m_cartPotision;
    [SerializeField] private GameObject m_lookAtPos;
    private RadioController m_redioController;
    private bool m_Initialized = false;
    private int m_reverse = 1;

    public bool IsSameCart(CinemachineDollyCart cartPosition)
    {
        if (cartPosition.gameObject == m_cartPotision.gameObject) return true;
        return false;
    }

    public void Initialize(RadioController radioController)
    {
        m_redioController = radioController;
        m_redioController.MoveSpeed = m_cartPotision.m_Speed;

        if(m_lookAtPos == null)
        {
            m_lookAtPos = GameObject.Find("DollyLookAt");
        }

        m_Initialized = true;
    }

    public void SetNextCart(CinemachineDollyCart cartPotision) =>m_cartPotision = cartPotision;
    public void SetNextLookat()
    {
        m_lookAtPos = null;
        m_lookAtPos = GameObject.Find("DollyLookAt");
    }

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
                m_reverse = -m_reverse;

                //íçéãì_Ç‡âÒì]ÇµÇƒÇ®Ç≠
                Vector3 pos = m_lookAtPos.transform.localPosition;
                pos.z = -pos.z;
                m_lookAtPos.transform.localPosition = pos;
            }
        }

        if (Keyboard.current.mKey.isPressed)
        {
            m_cartPotision.m_Speed = 3 * m_reverse;
        }
        else
        {
            m_cartPotision.m_Speed = 0;
        }

        m_redioController.LookAt(m_lookAtPos.transform);
        m_redioController.ChangeMoveAnimation(Mathf.Abs(m_cartPotision.m_Speed) );
    }
}
