using System;
using System.Collections.Generic;

namespace Stratego.Core
{
    public class StrategoBoardGeneratorClassic : IBoardGenerator {

        protected readonly List<Tuple<int, int>> _lockedFields = new List<Tuple<int, int>> {
            Tuple.Create(2, 4), Tuple.Create(3, 4), Tuple.Create(6, 4), Tuple.Create(7, 4),
            Tuple.Create(2, 5), Tuple.Create(3, 5), Tuple.Create(6, 5), Tuple.Create(7, 5)
        };

        public StrategoBoard DrawBoard() {
            var board = new StrategoBoard();

            for (int i = 0; i < board.Length; i++) {
                for (int y = 0; y < board.Height; y++) {

                    if(_lockedFields.Find(t => t.Item1 == i && t.Item2 == y) != null) {
                        board[i, y] = new Field() {
                            IsLocked = true,
                            Pawn = null
                        };
                    } else {
                        board[i, y] = new Field() {
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
