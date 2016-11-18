using System.Collections.Generic;

namespace Stratego.Game
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGameType
    {
        int CountOfPlayer { get; }
        IEnumerable<UnitInfo> GetAllUnits();
        IEnumerable<Terrain> GetAllTerrains();
    }
}
