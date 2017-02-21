using System;
using System.Collections.Generic;
using System.Linq;

namespace Stratego.Core
{
    public class StrategoPawnFactory
    {
        private readonly Dictionary<string, UnitInfo> _units = new Dictionary<string, UnitInfo>();
        private Func<UnitInfo, Guid, Pawn> _createPawn = (unit, id) => new Pawn(unit, id);

        public Pawn Create(string id, Guid playerId) {
            UnitInfo unit = null;
            if (_units.TryGetValue(id, out unit)) {
                return _createPawn(unit, playerId);
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
        }

        public void SetCreatePawnDel(Func<UnitInfo, Guid, Pawn> creator) {
            _createPawn = creator;
        }
    }
}
