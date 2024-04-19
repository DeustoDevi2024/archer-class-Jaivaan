using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class Startup : MonoBehaviour
    {

        [SerializeField]
        private Enemy[] enemies;

        private void Awake()
        {
            var scoreDisplays = new IScoreDisplay[] { new ConsoleScoreDisplay() };

            new ScoreManager(enemies, scoreDisplays);
        }

    }

}