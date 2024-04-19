using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class ConsoleScoreDisplay : IScoreDisplay
    {
        public void UpdateDisplay(float actualScore, float addedScore)
        {
            Debug.Log($"NewScore: {actualScore} (added: {addedScore}");
        }
    }

}