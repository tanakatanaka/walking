using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class CartReceiver : MonoBehaviour
{
    [SerializeField] private CinemachineDollyCart m_cartPotision;
    [SerializeField] private RadioController m_thirdPersonController;

    private void Start()
    {
        m_thirdPersonController.MoveSpeed = m_cartPotision.m_Speed;
    }


    // Update is called once per frame
    void Update()
    {
        //transform.position = m_cartPotision.transform.position;

        if (Keyboard.current.mKey.isPressed)
        {
            m_cartPotision.m_Speed = 3;
        }
        else
        {
            m_cartPotision.m_Speed = 0;
        }

        m_thirdPersonController.ChangeMoveAnimation(m_cartPotision.m_Speed);
    }
}
