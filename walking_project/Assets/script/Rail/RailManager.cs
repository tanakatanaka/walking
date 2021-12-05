using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RailManager : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private List<RailController> _rails = default;

    public List<RailController> Rails => _rails;

    public List<RailController> GetMoveAbleRails(CharacterManager playerManager)
    {
        return _rails.FindAll(c => !playerManager.IsMyaCart(c.Cart));
    }

    public List<string> GetRailsHashNameList()
    {
        List<string> railNameHash = new List<string>();
          _rails.ForEach(c => railNameHash.Add(c.RailNameHash));
        return railNameHash;
    }
}
