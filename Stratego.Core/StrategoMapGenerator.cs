using System;
using System.Collections.Generic;
using System.Linq;

namespace Stratego.Core
{
    public class StrategoMapGenerator : IMapGenerator
    {
        private readonly List<Terrain> _terrains;
        private readonly IGameType _type;

        public StrategoMapGenerator(IGameType type) {
            if (type == null) {
                throw new ArgumentNullException(nameof(type));
            }

            _type = type;
            _terrains = new List<Terrain>(type.GetAllTerrains());
        }

        public StrategoBoard DrawBoard() {
            var board = new StrategoBoard();

            for (int i = 1; i <= board.Length; i++) {
                for (int y = 1; y <= board.Height; y++) {
                    board[i, y] = new Field() {
                        Terrain = (from ter in _terrains where ter.TypeName == "TYPE_TERRAIN_FIELD" select ter).FirstOrDefault()
                    };
                }
            }

            return board;
        }
    }
}
