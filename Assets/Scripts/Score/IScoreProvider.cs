using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public interface IScoreProvider
    {

        public delegate void ScoreAddedHandler(float addedScore);
        event ScoreAddedHandler OnScoreAdded;

    }

}