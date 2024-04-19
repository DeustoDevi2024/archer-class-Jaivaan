using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer.Configuration
{

    public interface IGameConfigProvider
    {

        GameConfig Get();

    }

}