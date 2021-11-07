using UnityEngine;
using System.Collections.Generic;
#if UNITY_ANALYTICS
using UnityEngine.Analytics;
#endif

/// <summary>
/// The Game manager is a state machine, that will switch between state according to current gamestate.
/// </summary>
public class AppManager : MonoBehaviour
{
    public static AppManager instance = null;
    private string m_crrentScene = "Start";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
