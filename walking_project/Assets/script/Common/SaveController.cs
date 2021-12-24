using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree.Types;

namespace BayatGames.SaveGameFree.Examples
{
    public class SaveController : MonoBehaviour
    {
        private string _encodePassword;
        private GameInfo.GameData _targetData;
        public bool loadOnStart = true;
        public string identifier = "exampleSavePosition.dat";

        public GameInfo.GameData TargetData => _targetData;

        public void Save()
        {
            _targetData = GameManager.Instance.I_gameInfo.GetWorKData();
            SaveGame.Save<GameInfo.GameData>(identifier, _targetData, SerializerDropdown.Singleton.ActiveSerializer);
        }

        public void Load()
        {
            _targetData = SaveGame.Load<GameInfo.GameData>(
                identifier,
                new GameInfo.GameData(),
                SerializerDropdown.Singleton.ActiveSerializer);

            GameManager.Instance.I_gameInfo.SetUpPlayerData(_targetData);
        }
    }
}