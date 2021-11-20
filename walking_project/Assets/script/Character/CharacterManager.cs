using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using Cinemachine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private CartReceiver m_cartReceiver;
    [SerializeField] private RadioController m_radioController;

    // Start is called before the first frame update
    public void Initialize()
    {
        m_cartReceiver.Initialize(m_radioController);
    }

    public bool IsMyaCart(CinemachineDollyCart dollyCart)
    {
        return m_cartReceiver.IsSameCart(dollyCart);
    }


    public void SetNextCart(CinemachineDollyCart dollyCart)
    {
        m_cartReceiver.SetNextCart(dollyCart);
        m_radioController.transform.SetParent(dollyCart.transform);
    }


}
