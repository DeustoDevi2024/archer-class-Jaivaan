using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Archer.Persistence
{

    public class JsonGameStateProvider : IGameStateProvider
    {
        private string filePath;

        public JsonGameStateProvider(string path)
        {
            filePath = Path.Combine(Application.persistentDataPath, path);
        }

        public GameState Load()
        {
            if (!File.Exists(filePath))
            {
                return new GameState();
            }

            var json = File.ReadAllText(filePath);
            var gameState = JsonUtility.FromJson<GameState>(json);
            return gameState;
        }

        public void Save(GameState gameState)
        {
            var stateJson = JsonUtility.ToJson(gameState);
            File.WriteAllText(filePath, stateJson);
        }
    }

}