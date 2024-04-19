using Archer.Configuration;
using Archer.Persistence;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Archer
{

    public class AppLogic : MonoBehaviour
    {
        
        public static AppLogic Instance { get; private set; }

        private IGameConfigProvider gameConfigProvider;

        [SerializeField]
        private ScriptableObjectGameConfigProvider scriptableObjectGameConfigProvider;

        private GameState gameState;

        private IGameStateProvider gameStateProvider;//new PlayerPrefsGameStateProvider();

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            gameConfigProvider = scriptableObjectGameConfigProvider;//new JsonGameConfigProvider("game_config.json");

            gameStateProvider = new JsonGameStateProvider("state.json");

            gameState = gameStateProvider.Load();
        }

        public GameConfig GetGameConfig()
        {
            return gameConfigProvider.Get();
        }

        private void OnApplicationQuit()
        {
            gameState.timePlayed += Time.realtimeSinceStartup;
            gameStateProvider.Save(gameState);
            Debug.Log("PlayedTime : " + gameState.timePlayed);
        }

        public void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }

    }

}