using Montana;
using Stratego.Core.Def;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stratego.Core
{
    public class StrategoPawnFactory : IPawnFactory
    {
        /*private readonly Dictionary<string, UnitInfo> _units = new Dictionary<string, UnitInfo>();

        public Pawn Create(string id, Guid playerId) {
            UnitInfo unit = null;
            if (_units.TryGetValue(id, out unit)) {
                return new Pawn(unit, playerId);
            }

            throw new ArgumentException("No type registered for this id");
        }

        public void Register(UnitInfo unit) {
            if (unit != null) {
                _units.Add(unit.Type, unit);
            }
        }

        public List<UnitInfo> GetAllUnitInfo() {
            return _units.Values.ToList();
        }*/
        public IEnumerable<Pawn> BuildPawnSet()
        {
            var pawnSet = new List<Pawn>();

            new UnitInfo() {
                Type = "UNIT_FLAG",
                DisplayName = "TXT_NAME_UNIT_FLAG",
                Description = "TXT_DESC_UNIT_FLAG",
                MaxAvailable = 1,
                Rank = 0,
                SpecialSkill = SpecialSkill.Flag,
                MoveType = MoveType.None
            };

            // create set

            return pawnSet;
        }
    }
}
