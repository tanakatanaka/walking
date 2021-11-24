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
}
