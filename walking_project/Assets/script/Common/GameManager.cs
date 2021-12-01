using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager _instance { get { return Instance; } }
    static protected GameManager Instance;

    [SerializeField] private TextManager   _textManager;
    [SerializeField] private SceneController _sceneController;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _textManager.Initialize();
        _sceneController.Initialize();

        _sceneController.JumpNextScene("DebugMenu");
    }

    public void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
