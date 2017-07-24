using Stratego.Core.Def;
using System;
using System.Collections.Generic;

namespace Stratego.Core
{
    public class StrategoBoardGeneratorClassic : IBoardGenerator {

        protected readonly List<Tuple<int, int>> _lockedFields = new List<Tuple<int, int>> {
            Tuple.Create(2, 4), Tuple.Create(3, 4), Tuple.Create(6, 4), Tuple.Create(7, 4),
            Tuple.Create(2, 5), Tuple.Create(3, 5), Tuple.Create(6, 5), Tuple.Create(7, 5)
        };

        public IBoard DrawBoard() {
            var board = new StrategoBoard();

            for (int x = 0; x < board.Width; x++) {
                for (int y = 0; y < board.Height; y++) {
                    if(_lockedFields.Find(t => t.Item1 == x && t.Item2 == y) != null) {
                        board[x, y] = new Field() {
                            IsLocked = true,
                            Pawn = null
                        };
                    } else {
                        board[x, y] = new Field() {
                            IsLocked = false,
                            Pawn = null
                        };
                    }
                }
            }

            return board;
        }
    }
}
