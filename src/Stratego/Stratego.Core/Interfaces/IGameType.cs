﻿using System.Collections.Generic;

namespace Stratego.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGameType
    {
        int CountOfPlayer { get; }
        IBoardGenerator GetBoardGenerator();
        StrategoPawnFactory GetPawnFactory();
    }
}