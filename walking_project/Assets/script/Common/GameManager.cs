using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using BayatGames.SaveGameFree.Examples;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get { return _instance; } }
    static protected GameManager _instance;

    [SerializeField] private TextManager   _textManager;
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private MusicPlayer _musicPlayer;
    [SerializeField] private Flowchart _flowChart;
    [SerializeField] private SaveController _saveController;

    public TextManager I_TextManager => _textManager;
    public SceneController I_SceneController => _sceneController;
    public MusicPlayer I_MusicPlayer => _musicPlayer;
    public Flowchart I_FlowChart => _flowChart;
    public SaveController I_SaveController => _saveController;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _textManager.Initialize();
        _sceneController.Initialize();
        _musicPlayer.Initialize();

        if (_sceneController.IsCurrentScene("boot"))
        {
            _sceneController.JumpNextScene("menu");
            //_sceneController.LoadScenePrefab("menu");
        }
    }

    public void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
