using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RailManager : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private List<RailController> _rails = default;
    [SerializeField] private List<bool> _reverseList = default;
    private List<RailListInfo> _railInfoList;
        
    public class RailListInfo
    {
        public RailController _rail;
        public bool _isReverse;
    };

    public void Initialzie()
    {
        _railInfoList = new List<RailListInfo>();

        for (int i = 0; i < _rails.Count; i++)
        {
            var tmp = new RailListInfo();
            tmp._rail = _rails[i];
            tmp._isReverse = _reverseList[i];
            _railInfoList.Add(tmp);
        }
    }

    public List<RailListInfo> GetMoveAbleRailInfoList(CharacterManager playerManager)
    {
        return _railInfoList.FindAll(c => !playerManager.IsMyaCart(c._rail.Cart));
    }

    public bool IsReverseRail(int index)
    {
        return _reverseList[index];
    }


    public List<string> GetRailsHashNameList(CharacterManager playerManager)
    {
        List<string> railNameHash = new List<string>();
        foreach (var rail in _rails)
        {
            if (!playerManager.IsMyaCart(rail.Cart)) railNameHash.Add(rail.RailNameHash);
        }

        return railNameHash;
    }
}
