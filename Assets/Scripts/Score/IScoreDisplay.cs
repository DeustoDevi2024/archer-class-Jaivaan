using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public interface IScoreDisplay
    {

        void UpdateDisplay(float actualScore, float addedScore);

    }

}