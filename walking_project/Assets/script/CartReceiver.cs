using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;


public class CartReceiver : MonoBehaviour
{
    [SerializeField] private CinemachineDollyCart m_cartPotision;
    [SerializeField] private ThirdPersonController m_thirdPersonController;

    private void Start()
    {
        //m_thirdPersonController.MoveSpeed = m_cartPotision.m_Speed;
    }


    // Update is called once per frame
    void Update()
    {
        //transform.position = m_cartPotision.transform.position;
    }
}
