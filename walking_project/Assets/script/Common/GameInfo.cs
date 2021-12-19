using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using BayatGames.SaveGameFree.Examples;

public class GameInfo : MonoBehaviour
{
    private GameData _workData;
    private GameData _saveData;

    public class GameData
    {
        public Mode _gameMode = Mode.NONE;
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
        _workData = new GameData();
        _saveData = new GameData();
    }

    public void ChangeMode(GameData.Mode mode)
    {
        _workData._gameMode = mode;

        switch (mode)
        {
            case GameData.Mode.LOAD:
                GameManager.Instance.LoadData();
                break;
            case GameData.Mode.INGAME:
                GameManager.Instance.StartGame();
                break;
            default:
                break;
        }
    }


};
