using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree.Types;

namespace BayatGames.SaveGameFree.Examples
{
    public class SaveController : MonoBehaviour
    {
        private string _encodePassword;
        private GameInfo.GamePlayData _targetData;
        public bool loadOnStart = true;
        public string identifier = "exampleSavePosition.dat";

        public GameInfo.GamePlayData TargetData => _targetData;

        public void Save()
        {
            _targetData = GameManager.Instance.I_gameInfo.GetWorKData();
            SaveGame.Save<GameInfo.GamePlayData>(identifier, _targetData, SerializerDropdown.Singleton.ActiveSerializer);
        }

        public void Load()
        {
            _targetData = SaveGame.Load<GameInfo.GamePlayData>(
                identifier,
                new GameInfo.GamePlayData(),
                SerializerDropdown.Singleton.ActiveSerializer);

            GameManager.Instance.I_gameInfo.SetUpPlayerData(_targetData);
        }
    }
}