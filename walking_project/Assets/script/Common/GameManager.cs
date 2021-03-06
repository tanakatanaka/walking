using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using BayatGames.SaveGameFree.Examples;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get { return _instance; } }
    static protected GameManager _instance;

    [SerializeField] private TextManager   _textManager = default;
    [SerializeField] private SceneController _sceneController = default;
    [SerializeField] private MusicPlayer _musicPlayer = default;
    [SerializeField] private Flowchart _flowChart = default;
    [SerializeField] private SaveController _saveController = default;
    [SerializeField]  private GameInfo _gameInfo = default;

    public GameInfo I_gameInfo => _gameInfo;
    public TextManager I_TextManager => _textManager;
    public SceneController I_SceneController => _sceneController;
    public MusicPlayer I_MusicPlayer => _musicPlayer;
    public Flowchart I_FlowChart => _flowChart;

    // Start is called before the first frame update
    void Awake()
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
        _gameInfo.Initialize();
        LoadData();
        _musicPlayer.Initialize();


        if (_sceneController.IsCurrentScene("boot"))
        {
            _sceneController.JumpNextScene("menu");
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
        _sceneController.JumpNextScene("garden");
    }

    public void JumpNameScene(string name)
    {
        _sceneController.JumpNextScene(name);
    }

    public void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
