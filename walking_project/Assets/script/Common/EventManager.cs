using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private RailManager _railManager;
    [SerializeField] private List<EventBox> _eventBoxes = default;


    public void Initialize(CharacterManager playerManage)
    {
        _eventBoxes.ForEach(e => e?.Initialize(playerManage));
    }
    

}
