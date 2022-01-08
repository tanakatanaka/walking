using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using BayatGames.SaveGameFree.Examples;

public class GameInfo : MonoBehaviour
{
    private GamePlayData _workData;
    private GamePlayData _saveData;

    public class GamePlayData
    {
        public Mode _gameMode = Mode.NONE;
        public int _degreeProgress = 0;
        public bool _isFirstPlay = false;
        public float masterVolume = 20;
        public float musicVolume = 20;
        public float masterSFXVolume = 20;

        public enum Mode
        {
            NONE,
            MENU,
            SAVE,
            LOAD,
            INGAME,
        };
    }

    public void Initialize()
    {
        _workData = new GamePlayData();
        _saveData = new GamePlayData();
    }

    public GamePlayData GetWorKData()
    {
        return _workData;
    }

    public void SetUpPlayerData(GamePlayData gameData)
    {
        _workData = gameData;
        _saveData = gameData;
    }


    public void ChangeMode(GamePlayData.Mode mode)
    {
        _workData._gameMode = mode;

        switch (mode)
        {
            case GamePlayData.Mode.LOAD:
                GameManager.Instance.StartGame();
                break;
            case GamePlayData.Mode.INGAME:

                _workData = new GamePlayData();
                _workData._isFirstPlay = true;
                GameManager.Instance.StartGame();
                break;
            default:
                break;
        }
    }


};
