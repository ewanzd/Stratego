using Montana;
using Stratego.Core.Def;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Stratego.Core
{
    public class StrategoLogic : BaseGameLogic
    {
        private IBoard _board;

        private StrategoLogic()
        {

        }

        public override bool Init(string configResource)
        {
            var board = new StrategoBoard();
            board.Init(configResource);

            _board = board;

            return true;
        }

        public static StrategoLogic New(string configResource)
        {
            XElement root = XDocument.Parse(configResource).Root;

            var logic = new StrategoLogic();
            logic.Init(root.Value);

            return logic;
        }
    }

    /*public interface IGameConfig
    {
        IBoard CreateBoard();
        bool Init(XElement node);
    }

    public class GameConfig : IGameConfig
    {
        private IActorFactory _actorFactory;

        private int _boardWidth;
        private int _boardHeight;
        private IList<DefinedField> _definedFields;

        public IBoard CreateBoard()
        {
            var board = new StrategoBoard(_boardWidth, _boardHeight);

            foreach(var f in _definedFields)
            {
                var actor = _actorFactory.CreateActor(f.ActorResource);
                board.Place(f.Position, actor);
            }

            return board;
        }

        public bool Init(XElement node)
        {
            try
            {
                foreach (var fieldElement in node.Elements(XName.Get("PredefinedField")))
                {
                    var actorId = fieldElement.Element(XName.Get("ActorId")).Value;
                    var posElement = fieldElement.Element(XName.Get("Position"));
                    var xStr = Convert.ToInt32(posElement.Attribute(XName.Get("x")).Value);
                    var yStr = Convert.ToInt32(posElement.Attribute(XName.Get("y")).Value);

                    var field = new DefinedField();
                    _definedFields.Add(field);
                }
            }
            catch(Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                return false;
            }

            return true;
        }

        protected class DefinedField
        {
            private Position _position;
            public Position Position => _position;

            private string _actorResource;
            public string ActorResource => _actorResource;
            
        }
    }*/

    ///// <summary>
    ///// Central data object who moved between the states and objects.
    ///// </summary>
    //public class StrategoGame : BaseGameLogic
    //{
    //    // Game data
    //    private IBoard _board;

    //    private readonly IGameType _type;
    //    private int _currentPlayerPosition;
    //    private GameState _state;

    //    /// <summary>
    //    /// Game type from this game.
    //    /// </summary>
    //    public IGameType GameType { get { return _type; } }

    //    /// <summary>
    //    /// State of the game.
    //    /// </summary>
    //    public GameState CurrentGameState { get { return _state; } }

    //    /// <summary>
    //    /// Player, who can drag a unit.
    //    /// </summary>
    //    public int CurrentPlayer { get { return _currentPlayerPosition; } }

    //    /// <summary>
    //    /// Game state changed.
    //    /// </summary>
    //    public event EventHandler GameStateChanged;

    //    /// <summary>
    //    /// Create new game with any type of game.
    //    /// </summary>
    //    /// <param name="type">Type of game.</param>
    //    /// <param name="state"></param>
    //    /// <param name="currentPlayer"></param>
    //    protected StrategoGame(IGameType type, GameState state = GameState.New, int currentPlayer = 0) {
    //        //_type = type ?? new StrategoTypeClassic();
    //        _currentPlayerPosition = 0;
    //    }

    //    /// <summary>
    //    /// Create a new classic stratego game with two players.
    //    /// </summary>
    //    /// <param name="type"></param>
    //    /// <returns>Game.</returns>
    //    public static StrategoGame Create(IGameType type)
    //        => new StrategoGame(type);

    //    /// <summary>
    //    /// Change current player to next one.
    //    /// </summary>
    //    public void NextPlayer() {
    //        if (CurrentGameState != GameState.Running) {
    //            throw new InvalidOperationException($"Only possible in {GameState.Running.ToString()}.");
    //        }

    //        if(_currentPlayerPosition < _type.CountOfPlayer - 1) {
    //            _currentPlayerPosition++;
    //        } else {
    //            _currentPlayerPosition = 0;
    //        }
    //    }

    //    /// <summary>
    //    /// Game go to the next state.
    //    /// </summary>
    //    public void NextState() {
    //        if(_state < GameState.Closed) {
    //            _state++;
    //        } else {
    //            throw new InvalidOperationException("Game is already finished.");
    //        }
    //    }

    //    public override bool Init(string configResource)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
