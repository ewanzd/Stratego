using System.Collections.Generic;

namespace Stratego.Game
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGameType
    {
        int CountOfPlayer { get; }
        IMapGenerator GetMapGenerator();
        IEnumerable<UnitInfo> GetAllUnits();
        IEnumerable<Terrain> GetAllTerrains();
    }
}
