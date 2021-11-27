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
        //レール変更前
        m_cartReceiver.TurnLookAt();

        //レール変更後
        m_cartReceiver.SetNextRail(rail);
        m_radioController.transform.SetParent(rail.Cart.transform);
        m_cartReceiver.TurnPlayer();
    }

    public void SitTheSheet()
    {
        m_cartReceiver.SitMode();
    }


}
