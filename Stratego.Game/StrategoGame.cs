using System;
using System.Collections.ObjectModel;

namespace Stratego.Game
{
    public interface IGame
    {
        Guid Id { get; }
        int CountOfPlayer { get; }
        Guid GetPlayer(int order);
    }

    /// <summary>
    /// Create and manage a game.
    /// </summary>
    public sealed class StrategoGame : IGame
    {
        //private StrategoData data;
        private readonly Guid _gameId;
        private readonly ReadOnlyCollection<Guid> _listOfPlayers;
        //private bool benchHasBeenRegistered;

        /// <summary>
        /// The <see cref="System.Guid"/> of game.
        /// </summary>
        public Guid Id
        {
            get { return _gameId; }
        }

        ///// <summary>
        ///// The state of game.
        ///// </summary>
        //public GameState GameState
        //{
        //    get
        //    {
        //        return data.GameState;
        //    }
        //}

        ///// <summary>
        ///// Is the game active.
        ///// </summary>
        //public bool IsActive
        //{
        //    get { return data.IsActive; }
        //}

        ///// <summary>
        ///// Game is ready.
        ///// </summary>
        //public bool IsReady
        //{
        //    get { return IsActive && benchHasBeenRegistered; }
        //}

        ///// <summary>
        ///// Player one.
        ///// </summary>
        //public Guid PlayerOne { get { return _listOfPlayers[0]; } }

        ///// <summary>
        ///// Player two.
        ///// </summary>
        //public Guid PlayerTwo { get { return _listOfPlayers[1]; } }

        ///// <summary>
        ///// Game state changed.
        ///// </summary>
        //public event EventHandler GameStateChanged
        //{
        //    add { data.GameStateChanged += value; }
        //    remove { data.GameStateChanged -= value; }
        //}

        /// <summary>
        /// Get count of players.
        /// </summary>
        public int CountOfPlayer { get { return _listOfPlayers.Count; } }
        
        /// <summary>
        /// Create a new stratego game with two players.
        /// </summary>
        /// <param name="playerOne"></param>
        /// <param name="playerTwo"></param>
        public StrategoGame(Guid playerOne, Guid playerTwo)
        {
            _gameId = Guid.NewGuid();

            Guid[] players = new Guid[] { playerOne, playerTwo };
            _listOfPlayers = new ReadOnlyCollection<Guid>(players);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Guid GetPlayer(int order)
        {
            return _listOfPlayers[order];
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="data"></param>
        //private StrategoGame(StrategoData data)
        //{
        //    this.data = data;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="playerOne"></param>
        ///// <param name="playerTwo"></param>
        ///// <param name="source"></param>
        ///// <returns></returns>
        //public static StrategoGame NewGame(Guid playerOne, Guid playerTwo)
        //{
        //    // Initialize game
        //    var data = StrategoData.Create(playerOne, playerTwo);
        //    var game = new StrategoGame(data);

        //    return game;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="bench"></param>
        //public void RegisterBench(IBench bench)
        //{
        //    if (benchHasBeenRegistered) throw new InvalidOperationException("Bench has already been registered.");

        //    bench.NextPhase += Bench_NextPhase;
        //    benchHasBeenRegistered = true;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="bench"></param>
        //public void UnregisterBench(IBench bench)
        //{
        //    bench.NextPhase -= Bench_NextPhase;
        //    benchHasBeenRegistered = false;
        //}

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //    private void Bench_NextPhase(object sender, EventArgs e)
        //    {
        //        switch (data.GameState)
        //        {
        //            case GameState.Prep:
        //                data.SetStateInPlay();
        //                break;
        //            case GameState.InPlay:
        //                DateTime finishedTime = DateTime.Now;
        //                data.SetStateFinished(finishedTime);
        //                break;
        //        }
        //    }
        //}

        // Braucht es nur vor dem eigentlichen Spiel. Sammelt alle Settings (Unit, Terrain)
        //public class StrategoSettings
        //{
        //    private List<UnitInfo> units;
        //    private ISource source;

        //    public StrategoSettings(ISource source)
        //    {
        //        this.source = source;
        //        units = new List<UnitInfo>(source.GetAllUnits());
        //    }

        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <returns></returns>
        //    public IEnumerable<UnitInfo> GetAllUnit()
        //    {
        //        return units;
        //    }
        //}
    }
}
