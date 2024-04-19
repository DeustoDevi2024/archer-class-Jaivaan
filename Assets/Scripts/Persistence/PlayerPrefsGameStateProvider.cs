using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer.Persistence
{

    public class PlayerPrefsGameStateProvider : IGameStateProvider
    {
        public GameState Load()
        {
            return new GameState()
            {
                timePlayed = PlayerPrefs.GetFloat("timePlayed", 0)
            };
        }

        public void Save(GameState gameState)
        {
            PlayerPrefs.SetFloat("timePlayed", gameState.timePlayed);
        }
    }

}