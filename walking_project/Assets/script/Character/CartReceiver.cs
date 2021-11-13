using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class CartReceiver : MonoBehaviour
{
    [SerializeField] private CinemachineDollyCart m_cartPotision;
    private RadioController m_redioController;
    bool m_Initialized = false;
    int reverse = 1;

    public void Initialize(RadioController radioController)
    {
        m_redioController = radioController;
        m_redioController.MoveSpeed = m_cartPotision.m_Speed;
        m_Initialized = true;
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
                reverse = -reverse;
            }
        }


        if (Keyboard.current.mKey.isPressed)
        {
            m_cartPotision.m_Speed = 3 * reverse;
        }
        else
        {
            m_cartPotision.m_Speed = 0;
        }

        m_redioController.ChangeMoveAnimation(Mathf.Abs(m_cartPotision.m_Speed) );
    }
}
