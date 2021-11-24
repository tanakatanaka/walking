using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RailController : MonoBehaviour
{
    [SerializeField] private Transform m_lookAtTransform;
    [SerializeField] private CinemachineDollyCart m_cart;

    public CinemachineDollyCart Cart => m_cart;
    public Transform LookAtTransform => m_lookAtTransform;

    public bool IsRailEnd()
    {
        if (m_cart.m_Path.PathLength <= m_cart.m_Position + 1f) return true;

        return false;
    }


}
