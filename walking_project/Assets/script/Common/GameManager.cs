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

    private GameInfo _gameInfo;
    public GameInfo I_gameInfo => _gameInfo;
    public TextManager I_TextManager => _textManager;
    public SceneController I_SceneController => _sceneController;
    public MusicPlayer I_MusicPlayer => _musicPlayer;
    public Flowchart I_FlowChart => _flowChart;

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
        _gameInfo = new GameInfo();
        _gameInfo.Initialize();
        LoadData();


        if (_sceneController.IsCurrentScene("boot"))
        {
            _sceneController.JumpNextScene("menu");
            //_sceneController.LoadScenePrefab("menu");
        }
    }

    public void LoadData()
    {
        _saveController.Load();
    }

    public void SaveData()
    {
        _saveController.Save();
    }

    public void StartGame()
    {
        _sceneController.JumpNextScene("house");
    }

    public void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
