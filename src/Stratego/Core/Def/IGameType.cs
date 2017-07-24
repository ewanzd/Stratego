using System.Collections.Generic;

namespace Stratego.Core.Def
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGameType
    {
        int CountOfPlayer { get; }
        IBoardGenerator GetBoardGenerator();
        IPawnFactory GetPawnFactory();
    }
}
