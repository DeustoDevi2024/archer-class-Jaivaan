using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Archer.Configuration
{

    public class JsonGameConfigProvider : IGameConfigProvider
    {
        private string jsonPath;
        private GameConfig gameConfig;

        public JsonGameConfigProvider(string path)
        {
            jsonPath = Path.Combine(Application.streamingAssetsPath, path);
            string json = File.ReadAllText(jsonPath);
            gameConfig = JsonUtility.FromJson<GameConfig>(json);
        }

        public GameConfig Get()
        {
            return gameConfig;
        }
    }

}