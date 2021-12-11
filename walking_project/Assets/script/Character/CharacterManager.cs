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

    public void SetNextRail(RailManager.RailListInfo railInfo)
    {
        m_radioController.transform.SetParent(railInfo._rail.Cart.transform);
        m_cartReceiver.SetNextRail(railInfo._rail);
        m_cartReceiver.TurnCart(railInfo._isReverse);
        m_cartReceiver.TurnPlayer();
    }

    public void SitTheSheet()
    {
        m_cartReceiver.SitMode();
    }


}
