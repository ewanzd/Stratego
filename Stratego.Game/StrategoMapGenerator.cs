using Montana;
using System.Collections.Generic;
using System.Linq;

namespace Stratego.Game
{
    public class StrategoMapGenerator : IBoardInitializer
    {
        private List<Terrain> terrains;
        private ISource source;

        public StrategoMapGenerator(ISource source)
        {
            this.source = source;
            terrains = new List<Terrain>(source.GetAllTerrains());
        }

        public Board<Field> Initialize(Board<Field> board)
        {
            for (int i = 1; i <= board.Length; i++)
            {
                for (int y = 1; y <= board.Height; y++)
                {
                    board[i, y] = new Field()
                    {
                        Terrain = (from ter in terrains where ter.TypeName == "TYPE_TERRAIN_FIELD" select ter).FirstOrDefault()
                    };
                }
            }

            return board;
        }
    }
}
