using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public interface ISource
    {
        IEnumerable<UnitInfo> GetAllUnits();
        IEnumerable<Terrain> GetAllTerrains();
    }

    public class StrategoSource : ISource
    {
        public IEnumerable<Terrain> GetAllTerrains()
        {
            return new List<Terrain>()
            {
                 new Terrain()
                {
                    TypeName = "TYPE_TERRAIN_FIELD",
                    IsLock = false,
                    Name = "TXT_NAME_TERRAIN_FIELD",
                    Description = "TXT_DESC_TERRAIN_FIELD"
                }
            };
        }

        public IEnumerable<UnitInfo> GetAllUnits()
        {
            return new List<UnitInfo>()
            {
                new UnitInfo()
                {
                    Type = "PAWN_FLAG",
                    Name = "TXT_NAME_FLAG",
                    Description = "TXT_DESC_FLAG",
                    MaxAvailable = 1,
                    Power = 0,
                    SpecialUnit = SpecialUnit.Flag,
                    MoveType = Montana.MoveType.None
                }
            };
        }
    }
}
