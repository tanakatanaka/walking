using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree.Types;

namespace BayatGames.SaveGameFree.Examples
{
    public class SaveController : MonoBehaviour
    {
        [System.Serializable]
        public class StorageSG
        {
            public System.DateTime myDateTime;

            public StorageSG()
            {
                myDateTime = System.DateTime.UtcNow;
            }
        }
        public class SaveInfo : MonoBehaviour
        {
            private string _encodePassword;

            public Transform target;
            public bool loadOnStart = true;
            public string identifier = "exampleSavePosition.dat";

            public void Save()
            {
                SaveGame.Save<Vector3Save>(identifier, target.position, SerializerDropdown.Singleton.ActiveSerializer);
            }

            public void Load()
            {
                target.position = SaveGame.Load<Vector3Save>(
                    identifier,
                    Vector3.zero,
                    SerializerDropdown.Singleton.ActiveSerializer);
            }

        }
    }
}