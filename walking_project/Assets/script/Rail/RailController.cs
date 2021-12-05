using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RailController : MonoBehaviour
{
    [SerializeField] private string _railNameHash;
    [SerializeField] private CinemachineDollyCart m_cart;

    private Transform _lookAtTransform;
    public CinemachineDollyCart Cart => m_cart;
    public Transform LookAtTransform => _lookAtTransform;
    public string RailNameHash => _railNameHash;

    public bool IsRailEnd()
    {
        if (m_cart.m_Path.PathLength <= m_cart.m_Position + 1f) return true;

        return false;
    }

    public bool IsRailStart()
    {
        if (0 <= m_cart.m_Position + 1f) return true;

        return false;
    }


}
