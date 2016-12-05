using Montana;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Stratego.Game
{
    public class StrategoMapGenerator : IMapGenerator
    {
        private readonly List<Terrain> _terrains;
        private readonly IGameType _type;

        public StrategoMapGenerator() : this(null)
        {

        }

        public StrategoMapGenerator(IGameType type)
        {
            _type = type ?? new StrategoTypeClassic();
            _terrains = new List<Terrain>(type.GetAllTerrains());
        }

        public StrategoBoard DrawBoard()
        {
            StrategoBoard board = new StrategoBoard();

            for (int i = 1; i <= board.Length; i++)
            {
                for (int y = 1; y <= board.Height; y++)
                {
                    board[i, y] = new Field()
                    {
                        Terrain = (from ter in _terrains where ter.TypeName == "TYPE_TERRAIN_FIELD" select ter).FirstOrDefault()
                    };
                }
            }

            return board;
        }
    }
}
