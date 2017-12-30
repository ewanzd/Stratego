using Montana;
using Stratego.Core.Def;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stratego.Core
{
    public class MovementComponent : ActorComponent
    {
        private static ulong _componentId;
        public override ulong ComponentId => _componentId;

        private IBoard _board;

        protected IBoard Board { get => _board; }

        public event EventHandler<MoveEventArgs> Moved;

        private Position _position;
        public Position Position { get => _position; internal set => _position = value; }

        private MoveType _moveType;
        public MoveType MoveType { get => _moveType; set => _moveType = value; }

        private int _maxRange;
        public int MaxRange { get => _maxRange; set => _maxRange = value; }

        protected virtual void OnMoved(MoveEventArgs e)
        {
            Moved?.Invoke(this, e);
        }

        public void Place(Position pos)
        {
            this.Board.Place(pos, Owner);
            this.Position = pos;
        }

        public void Remove()
        {
            this.Board.Remove(Position);
            this.Position = null;
        }

        public void Move(Position to)
        {
            MovementComponent moveComp = this;

            if (moveComp.Position == null) throw new ArgumentException("Pawn must has a position.");
            if (to == null) throw new ArgumentNullException(nameof(to));

            var from = moveComp.Position;
            if (from.CompareTo(to) == 0) return;

            if (GetPossibleMoves().Find(p => p.CompareTo(to) == 0) != null)
            {
                throw new ArgumentException("Move isn't possible.");
            }

            var target = _board[to.X, to.Y];

            if (target != null)
            {
                var offender = Owner.GetComponent<CombatComponent>(0);
                var defender = target.GetComponent<CombatComponent>(0);
                var targetMoveAbility = target.GetComponent<MovementComponent>(0);

                var result = offender.Fight(defender);
                switch (result)
                {
                    case FightResult.Draw:
                        Remove();
                        targetMoveAbility.Remove();
                        break;
                    case FightResult.Win:
                        targetMoveAbility.Remove();
                        Place(to);
                        break;
                    case FightResult.Lose:
                        Remove();
                        break;
                }
            }
            else
            {
                Place(to);
            }
        }

        public List<Position> GetPossibleMoves()
        {
            MovementComponent moveComp = this;

            if (moveComp.Position == null) throw new ArgumentException("Pawn must have a position.");

            var pos = moveComp.Position;
            var moveType = moveComp.MoveType;
            var maxRange = moveComp.MaxRange;
            var possiblePos = new List<Position>();

            if (moveType.Is(MoveType.None) || maxRange == 0) return possiblePos;

            Action<int, int> way = (stepX, stepY) => {

                int currentRange = 1, x = pos.X + stepX, y = pos.Y + stepY;
                while (currentRange <= maxRange && x >= 0 && x < _board.Width && y >= 0 && y < _board.Height &&
                 _board[x, y] != null)
                {

                    possiblePos.Add(new Position(x, y));

                    currentRange++;
                    x += stepX;
                    y += stepY;
                }
            };

            if (moveType.Has(MoveType.Cross))
            {
                way(1, 0);
                way(-1, 0);
                way(0, 1);
                way(0, -1);
            }
            if (moveType.Has(MoveType.Diagonal))
            {
                way(1, 1);
                way(-1, 1);
                way(1, -1);
                way(-1, -1);
            }

            return possiblePos;
        }
    }
}
