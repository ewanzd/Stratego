using Montana;
using System.Collections.Generic;
using System;

namespace Stratego.Game
{
    /// <summary>
    /// Default type. Contain all units and fields.
    /// </summary>
    public class StrategoTypeClassic : IGameType
    {
        private const int COUNTOFPLAYER = 2;
        private readonly StrategoMapGenerator _mapGenerator;

        public int CountOfPlayer { get { return COUNTOFPLAYER; } }

        public StrategoTypeClassic()
        {
            _mapGenerator = new StrategoMapGenerator(this);
        }

        public IEnumerable<Terrain> GetAllTerrains()
        {
            return new List<Terrain>()
            {
                new Terrain()
                {
                    TypeName = "TERRAIN_FIELD",
                    IsLock = false,
                    DisplayName = "TXT_NAME_TERRAIN_FIELD",
                    Description = "TXT_DESC_TERRAIN_FIELD"
                },
                new Terrain()
                {
                    TypeName = "TERRAIN_LAKE",
                    IsLock = true,
                    DisplayName = "TXT_NAME_TERRAIN_LAKE",
                    Description = "TXT_DESC_TERRAIN_LAKE"
                }
            };
        }

        public IEnumerable<UnitInfo> GetAllUnits()
        {
            return new List<UnitInfo>()
            {
                new UnitInfo()
                {
                    Type = "UNIT_FLAG",
                    DisplayName = "TXT_NAME_UNIT_FLAG",
                    Description = "TXT_DESC_UNIT_FLAG",
                    MaxAvailable = 1,
                    Rank = 0,
                    SpecialUnit = SpecialUnit.Flag,
                    MoveType = MoveType.None
                }
            };
        }

        public IMapGenerator GetMapGenerator()
        {
            return _mapGenerator;
        }
    }
}
