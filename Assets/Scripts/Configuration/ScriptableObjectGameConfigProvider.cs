using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer.Configuration
{

    [CreateAssetMenu(fileName = "GameConfig", menuName = "Archer/Create GameConfig")]
    public class ScriptableObjectGameConfigProvider : ScriptableObject, IGameConfigProvider
    {

        [SerializeField]
        private GameConfig gameConfig;

        public GameConfig Get()
        {
            return gameConfig;
        }
    }

}