using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private CartReceiver m_cartReceiver;
    [SerializeField] private RadioController m_radioController;
    //[SerializeField] private RadioController m_radioController;

    // Start is called before the first frame update
    void Start()
    {
        m_cartReceiver.Initialize(m_radioController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
