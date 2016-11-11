using Montana;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stratego.Game
{
    public interface IGame
    {
        void RegisterBench(IBench bench);
    }

    // Erstellt und verwaltet ein Spiel und fasst die notwendige Daten und Objekte zusammen.
    /// <summary>
    /// Create and manage a game.
    /// 1) Use 'New' static method to create a game.
    /// 2) Take bench.
    /// 3) Take settings and set all pawns on the board.
    /// 4) Play.
    /// </summary>
    public sealed class StrategoGame : IGame
    {
        private StrategoData data;
        private bool benchHasBeenRegistered;

        /// <summary>
        /// The <see cref="System.Guid"/> of game.
        /// </summary>
        public Guid Id
        {
            get { return data.Id; }
        }

        /// <summary>
        /// The state of game.
        /// </summary>
        public GameState GameState
        {
            get
            {
                return data.GameState;
            }
        }

        /// <summary>
        /// Is the game active.
        /// </summary>
        public bool IsActive
        {
            get { return data.IsActive; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReady
        {
            get { return IsActive && benchHasBeenRegistered; }
        }

        /// <summary>
        /// Game state changed.
        /// </summary>
        public event EventHandler GameStateChanged
        {
            add { data.GameStateChanged += value; }
            remove { data.GameStateChanged -= value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private StrategoGame(StrategoData data)
        {
            this.data = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerOne"></param>
        /// <param name="playerTwo"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static StrategoGame New(Guid playerOne, Guid playerTwo)
        {
            // Initialize game
            var data = StrategoData.Create(playerOne, playerTwo);
            var game = new StrategoGame(data);

            return game;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bench"></param>
        public void RegisterBench(IBench bench)
        {
            if (benchHasBeenRegistered) throw new InvalidOperationException("Bench has already been registered.");

            bench.KingFailed += Bench_KingFailed;
            benchHasBeenRegistered = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bench_KingFailed(object sender, EventArgs e)
        {
            DateTime finishedTime = DateTime.Now;
            data.SetStateFinished(finishedTime);
        }
    }

    // Braucht es nur vor dem eigentlichen Spiel. Sammelt alle Settings (Unit, Terrain)
    public class StrategoSettings
    {
        private List<UnitInfo> units;
        private ISource source;

        public StrategoSettings(ISource source)
        {
            this.source = source;
            units = new List<UnitInfo>(source.GetAllUnits());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UnitInfo> GetAllUnit()
        {
            return units;
        }
    }

    public class BoardInitializer : IBoardInitializer
    {
        private List<Terrain> terrains;
        private ISource source;

        public BoardInitializer(ISource source)
        {
            this.source = source;
            terrains = new List<Terrain>(source.GetAllTerrains());
        }

        public Board<Field> Initialize(Board<Field> board)
        {
            for(int i = 1; i <= board.Length; i++)
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
