using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RailManager : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private List<RailController> m_rails = default;

    public List<RailController> Rails => m_rails;

    public List<RailController> GetMoveAbleRails(CharacterManager playerManager)
    {
        return m_rails.FindAll(c => !playerManager.IsMyaCart(c.Cart));
    }
}
