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


    public void SetNextRail(RailController rail)
    {
        if (m_cartReceiver.MyRail.IsRailEnd())
        {
            m_cartReceiver.TurnLookAt();
        }
        m_cartReceiver.SetNextRail(rail);
        m_radioController.transform.SetParent(rail.Cart.transform);
    }


}
