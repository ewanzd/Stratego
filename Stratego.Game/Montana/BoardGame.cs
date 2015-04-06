using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    public abstract class BoardGame<summary> : GameBase<summary>
        where summary : BoardGameSummary, new()
    {
        // Grundlogik für alle Brettspiele mit Felder.

        protected Board<FieldBase> board;

        public BoardGame()
        {
            board = new Board<FieldBase>(10, 10);
        }

        public BoardGame(summary sum)
        {

        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
        }

        public virtual bool MakeMove(GameMove move)
        {
            return false;
        }

        public override summary GetSummary()
        {
            var sum = base.GetSummary();

            return sum;
        }
    }
}
